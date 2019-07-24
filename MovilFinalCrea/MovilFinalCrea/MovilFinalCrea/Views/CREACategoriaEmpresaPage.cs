using MovilFinalCrea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MovilFinalCrea.Views
{
	public class CREACategoriaEmpresaPage : ContentPage
	{
        Xamarin.Forms.ListView ListViewCategoria;
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

            PaginaPrincipal.Children.Add(ListViewCategoria);
            Content = PaginaPrincipal;
        }

        private void ListViewCategoria_Refreshing(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ListViewCategoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }

        private async void ListViewCategoria_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await DisplayAlert("Notificacion", "Bienvenido"+((clsCategoriaEmpresa)e.Item).IdCategoria, "Aceptar");
            
        }
    }
}