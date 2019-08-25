using MovilFinalCrea.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovilFinalCrea.Views
{
    public class CREAPrincipalPage : ContentPage
    {
        Button EntNosotros = null, EntNComunidad = null, EntNoticias = null, EntCalendario = null;
        public CREAPrincipalPage()
        {
            this.BackgroundColor = Color.FromHex("#EDE7E1");
            
           var Logo = new Image
            {
                Source = "CREA_POSITIVO_SELLING_LINE.png",
                WidthRequest = 200,
                HeightRequest = 200,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,

            };
            EntNosotros = new Button
            {
                Text = "Nosotros",
                TextColor = Color.FromHex("#EDE7E1"),
                BackgroundColor = Color.FromHex("#004f6d"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                CornerRadius = 8,
                Image = "grupo.png", //128px
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Bottom, 0),
                IsEnabled = true,

            };
            EntNComunidad = new Button
            {
                Text = "Comunidad",
                TextColor = Color.FromHex("#EDE7E1"),
                BackgroundColor = Color.FromHex("#004f6d"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                CornerRadius = 8,
                Image = "mundial.png", //128px
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Bottom, 0),
                IsEnabled = true,

            };

            EntNoticias = new Button
            {
                Text = "Noticias",
                TextColor = Color.FromHex("#EDE7E1"),
                BackgroundColor = Color.FromHex("#004f6d"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                CornerRadius = 8,
                Image = "noticias.png", //128px
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Bottom, 0),
                IsEnabled = true,

            };
            EntCalendario = new Button
            {
                Text = "Calendario",
                TextColor = Color.FromHex("#EDE7E1"),
                BackgroundColor = Color.FromHex("#004f6d"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                CornerRadius = 8,
                Image = "calendario.png", //128px
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Bottom, 0),
                IsEnabled = true,
            };
            var grid = new Grid();
            var layoutprincipal = new StackLayout
            {
                Padding = new Thickness(12, 12, 12, 12),
                Margin = new Thickness(12, 12, 12, 12),
                BackgroundColor = Color.FromHex("#EDE7E1"),

            };

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


            grid.Children.Add(EntNosotros, 0, 0);
            grid.Children.Add(EntNComunidad, 1, 0);
            grid.Children.Add(EntNoticias, 0, 1);
            grid.Children.Add(EntCalendario, 1, 1);

            //Botones Accion
            EntNComunidad.Clicked += EntNComunidad_Clicked;
            EntNosotros.Clicked += EntNosotros_Clicked;

         

            layoutprincipal.Children.Add(Logo);
            layoutprincipal.Children.Add(grid);
            NavigationPage.SetHasNavigationBar(this, false);//Quitar la barra de navegación

           // ToolbarItem item 
            Content = layoutprincipal;

        }
        private async void EntNosotros_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CREANosotrosPage());
            // Application.Current.MainPage.Navigation.RemovePage(this);
        }

        private async void EntNComunidad_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(1000);
                RestClient Cliente = new RestClient("http://192.168.1.3/ApiCrea/api/Categoria_Empresa");
                RestRequest Request = new RestRequest("/TraerBuscador", Method.GET) { RequestFormat = DataFormat.Json };

                var response = Cliente.Execute(Request);

                List<clsCategoriaEmpresa> contenido = JsonConvert.DeserializeObject<List<clsCategoriaEmpresa>>(response.Content);

                if (contenido != null)
                {
                    App.ListCategoriaEmp = contenido;
                    await Application.Current.MainPage.Navigation.PushAsync(new CREACategoriaEmpresaPage());
                    //Application.Current.MainPage.Navigation.RemovePage(this);
                }
                else
                {
                    await DisplayAlert("Notificacion", "No se encontro ningun registro asociado a su palabra clave", "Aceptar");
                    return;
                }
            }
            catch (Exception x)
            {
                await DisplayAlert("Notificacion", "Error: " + x.Message, "Aceptar");
                return;
            }

        }
    }
}