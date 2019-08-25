using MovilFinalCrea.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovilFinalCrea.Views
{
	public class CREACategoriaEmpresaPage : ContentPage
	{
        Xamarin.Forms.ListView ListViewCategoria;
        SearchBar searchBar = null;
        public CREACategoriaEmpresaPage ()
		{
            StackLayout PaginaPrincipal = new StackLayout { HorizontalOptions = LayoutOptions.Center };
            ListViewCategoria = new Xamarin.Forms.ListView();
            ListViewCategoria.ItemsSource = App.ListCategoriaEmp;
            ListViewCategoria.ItemTemplate = new DataTemplate(typeof(ViewCellCategoriasPage));

            ListViewCategoria.ItemTapped += ListViewCategoria_ItemTapped;
            ListViewCategoria.ItemSelected += ListViewCategoria_ItemSelected;
            ListViewCategoria.RowHeight = 80;
            ListViewCategoria.IsPullToRefreshEnabled = true;
            ListViewCategoria.Refreshing += ListViewCategoria_Refreshing;

            searchBar = new SearchBar {
               Placeholder="Palabras Clave",
               TextColor= Color.Black,
               BackgroundColor= Color.White

            };
            searchBar.SearchButtonPressed += SearchBar_SearchButtonPressed;


            PaginaPrincipal.Children.Add(searchBar);
            PaginaPrincipal.Children.Add(ListViewCategoria);
            Content = PaginaPrincipal;
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(1000);
                string id = searchBar.Text;
                string opcion = "2";
                RestClient Cliente = new RestClient("http://192.168.1.3/ApiCrea/api/Categoria_Empresa");
                RestRequest Request = new RestRequest("/TraerEmpresas?content=" + id + "&opcion=" + opcion, Method.GET) { RequestFormat = DataFormat.Json };

                var response = Cliente.Execute(Request);

                List<clsEmpresa> contenido = JsonConvert.DeserializeObject<List<clsEmpresa>>(response.Content);

                if (contenido != null && contenido.Count!=0)
                {
                    App.ListEmpresa = contenido;
                    await Application.Current.MainPage.Navigation.PushAsync(new CREAEmpresaCPage());
                   // Application.Current.MainPage.Navigation.RemovePage(this);
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

        private void ListViewCategoria_Refreshing(object sender, EventArgs e)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }

        private void ListViewCategoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }

        private async void ListViewCategoria_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            try
            {
                await Task.Delay(1000);
                string id = Convert.ToString(((clsCategoriaEmpresa)e.Item).IdCategoria);
                string opcion = "1";
                RestClient Cliente = new RestClient("http://192.168.1.3/ApiCrea/api/Categoria_Empresa");
                RestRequest Request = new RestRequest("/TraerEmpresas?content="+id+"&opcion="+opcion, Method.GET) { RequestFormat = DataFormat.Json };
               
                var response = Cliente.Execute(Request);
               
                List<clsEmpresa> contenido = JsonConvert.DeserializeObject<List<clsEmpresa>>(response.Content);

                if (contenido != null)
                {
                    App.ListEmpresa = contenido;
                    await Application.Current.MainPage.Navigation.PushAsync(new CREAEmpresaCPage());
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
           // await DisplayAlert("Notificacion", "Bienvenido"+((clsCategoriaEmpresa)e.Item).IdCategoria, "Aceptar");
            
        }
    }
}