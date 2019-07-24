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
            EntNosotros = new Button
            {
                Text = "Nosotros",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#FFE242"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                CornerRadius = 1,
                Image = "nosotros.png", //128px
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Bottom, 0),
                IsEnabled = true,

            };
            EntNComunidad = new Button
            {
                Text = "Comunidad",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#3498DB"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                CornerRadius = 1,
                Image = "Comunidad.png", //128px
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Bottom, 0),
                IsEnabled = true,

            };

            EntNoticias = new Button
            {
                Text = "Noticias",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#1ABC9C"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                CornerRadius = 1,
                Image = "noticias.png", //128px
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Bottom, 0),
                IsEnabled = true,

            };
            EntCalendario = new Button
            {
                Text = "Calendario",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#85929E"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                CornerRadius = 1,
                Image = "calendario.png", //128px
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Bottom, 0),
                IsEnabled = true,
            };
            var grid = new Grid();

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


            Content = grid;

        }

        private async void EntNosotros_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new CREANosotrosPage()));
            Navigation.RemovePage(this);
        }

        private async void EntNComunidad_Clicked(object sender, EventArgs e)
        {
            try
            {
               await Task.Delay(1000);
                RestClient Cliente = new RestClient("http://localhost:64903/api/Categoria_Empresa");
                RestRequest Request = new RestRequest("/TraerBuscador", Method.GET) { RequestFormat = DataFormat.Json };
                //Request.AddBody(obclstbRestaurante);
                var response = Cliente.Execute(Request);
               /* var httpCliente = new HttpClient();
                await Task.Delay(3000);
                var response = await httpCliente.GetStringAsync("http://localhost:64903/api/Categoria_Empresa/TraerBuscador");
                */
                List<clsCategoriaEmpresa> contenido = JsonConvert.DeserializeObject<List<clsCategoriaEmpresa>>(response.Content);

                if (contenido != null)
                {
                    App.ListCategoriaEmp = contenido;
                    await Navigation.PushAsync(new NavigationPage(new CREACategoriaEmpresaPage()));
                    Navigation.RemovePage(this);
                }
                else
                {
                    await DisplayAlert("Notificacion", "No se encontro ningun registro asociado a su palabra clave", "Aceptar");
                    return;
                }
            }
            catch (Exception x)
            {
                await DisplayAlert("Notificacion", "Error: "+x.Message, "Aceptar");
                return;
            }
            
        }
    }
}