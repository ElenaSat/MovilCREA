using MovilFinalCrea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MovilFinalCrea.Views
{
	public class CREAEmpresaCPage : ContentPage
	{
        Xamarin.Forms.ListView ListViewEmpresa;
        public CREAEmpresaCPage ()
		{
            StackLayout PaginaPrincipal = new StackLayout { HorizontalOptions = LayoutOptions.Center };
            ListViewEmpresa = new Xamarin.Forms.ListView();
            ListViewEmpresa.ItemsSource = App.ListEmpresa;
            ListViewEmpresa.ItemTemplate = new DataTemplate(typeof(ViewCellEmpresaPage));

            ListViewEmpresa.ItemTapped += ListViewEmpresa_ItemTapped;
            ListViewEmpresa.ItemSelected += ListViewEmpresa_ItemSelected;
            ListViewEmpresa.RowHeight = 80;
            ListViewEmpresa.IsPullToRefreshEnabled = true;
            ListViewEmpresa.Refreshing += ListViewEmpresa_Refreshing;

            PaginaPrincipal.Children.Add(ListViewEmpresa);
            Content = PaginaPrincipal;
        }

        private void ListViewEmpresa_Refreshing(object sender, EventArgs e)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }

        private void ListViewEmpresa_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }

        private async void ListViewEmpresa_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            clsEmpresa objEmpresa = new clsEmpresa();
            objEmpresa = (clsEmpresa)e.Item;
            await Application.Current.MainPage.Navigation.PushAsync(new CREAEmpresaUsuarioPage(objEmpresa));
            //Application.Current.MainPage.Navigation.RemovePage(this);
        }
    }
}