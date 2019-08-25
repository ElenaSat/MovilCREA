using MovilFinalCrea.Models;
using MovilFinalCrea.Services;
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
    public class CREARegistroPage : ContentPage
    {
        Entry EntNombre = null, EntApellido = null, EntCedula = null, EntCorreo = null,
           EntPassword = null,
           EntVePassword = null;
        ActivityIndicator _loading;
        public CREARegistroPage()
        {
            _loading = new ActivityIndicator { IsRunning = true, IsVisible = false };
            this.BackgroundColor = Color.FromHex("#004f6d");
            this.Title = "Registro";
                   
            var Logo = new Image
            {
                Source = "CREA_NEGATIVO_SELLING_LINE.png",
                WidthRequest = 200,
                HeightRequest = 200,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                
            };

            Label LbRegistro = new Label()
            {
                TextColor = Color.FromHex("#EDE7E1"),
                Text = "Registro",
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Label lbInformacionDatosPersonales = new Label()
            {
                TextColor = Color.FromHex("#BAA209"),
                Text = "Datos Personales",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Label lbInformacionDatosCuenta = new Label()
            {
                TextColor = Color.FromHex("#BAA209"),
                Text = "Datos de la Cuenta",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center
            };

            EntNombre = new Entry()
            {
                Placeholder = "Nombres",
                FontSize = 14,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Start,
                Keyboard = Keyboard.Text,
                PlaceholderColor=Color.White,
            };
            EntApellido = new Entry()
            {
                Placeholder = "Apellidos",
                FontSize = 14,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Start,
                Keyboard = Keyboard.Text,
                PlaceholderColor = Color.White,
            };
            EntCedula = new Entry()
            {
                Placeholder = "Número de Cédula",
                FontSize = 14,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Start,
                Keyboard = Keyboard.Telephone,
                PlaceholderColor = Color.White,
            };
            EntCorreo = new Entry()
            {
                Placeholder = "Correo",
                FontSize = 14,
                Keyboard = Keyboard.Email,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Start,
                PlaceholderColor = Color.White,
            };
            EntPassword = new Entry()
            {
                Placeholder = "Contraseña",
                FontSize = 14,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Start,
                IsPassword = true,
                PlaceholderColor = Color.White,
            };
            EntVePassword = new Entry()
            {
                Placeholder = "Verificar Contraseña",
                FontSize = 14,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Start,
                IsPassword = true,
                PlaceholderColor = Color.White,
            };

            Label lbRedesSociales = new Label()
            {
                TextColor = Color.FromHex("#BAA209"),
                Text = "Registro con Redes Sociales",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var ImgFacebook = new Image
            {
                Source = "facebook.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                IsVisible = true,
                WidthRequest = 30,
                HeightRequest = 30,

            };
            var ImgInstagram = new Image
            {

                Source = "instagram.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                IsVisible = true,
                WidthRequest = 30,
                HeightRequest = 30,
            };
            var ImgInliked = new Image
            {

                Source = "linkedin.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                IsVisible = true,
                WidthRequest = 30,
                HeightRequest = 30,

            };

            Button btGuardar = new Button
            {
                Text = "Guardar",
                TextColor = Color.FromHex("#004f6d"),
                BackgroundColor = Color.FromHex("#EDE7E1"),
                FontAttributes = FontAttributes.Bold,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                CornerRadius = 20,
            };

            var Registro = new StackLayout
            {
                Padding = new Thickness(12, 12, 12, 12),
                Margin = new Thickness(12, 12, 12, 12),
                BackgroundColor = Color.FromHex("#004f6d"),

            };
            var grid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


            grid.Children.Add(ImgInstagram, 0, 0);
            grid.Children.Add(ImgFacebook, 1, 0);
            grid.Children.Add(ImgInliked, 2, 0);

            btGuardar.Clicked += BtGuardar_Clicked;

            Registro.Children.Add(Logo);
            Registro.Children.Add(LbRegistro);
            Registro.Children.Add(lbInformacionDatosCuenta);
            Registro.Children.Add(EntCorreo);
            Registro.Children.Add(EntPassword);
            Registro.Children.Add(EntVePassword);

            Registro.Children.Add(lbInformacionDatosPersonales);
            Registro.Children.Add(EntNombre);
            Registro.Children.Add(EntApellido);
            Registro.Children.Add(EntCedula);
            Registro.Children.Add(lbRedesSociales);
            Registro.Children.Add(grid);
            Registro.Children.Add(_loading);
            Registro.Children.Add(btGuardar);

            NavigationPage.SetHasNavigationBar(this, false);//Quitar la barra de navegación

            Content = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical, // ScrollOrientation.Horizontal
                Content = Registro

            };


        }

        private async void BtGuardar_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(EntNombre.Text) || string.IsNullOrEmpty(EntApellido.Text) || string.IsNullOrEmpty(EntCedula.Text)
                || string.IsNullOrEmpty(EntCorreo.Text) || string.IsNullOrEmpty(EntPassword.Text) || string.IsNullOrEmpty(EntVePassword.Text))
            {
                await DisplayAlert("Notificación", "Digite todos los campos", "Aceptar");
                return;
            }
            else
            {
                _loading.IsVisible = true;
                DesactivarCampos();
                clsUsers users = new clsUsers();
                users.User_Id = 0;
                users.UserName = EntNombre.Text;
                users.UserLastName = EntApellido.Text;
                users.UserIdentificationCard = EntCedula.Text;
                users.UserEmail = EntCorreo.Text;
                users.UserConfirmeEmail = true;
                users.UserPassword = EntPassword.Text;
                users.UserTermConditions = true;

                await Task.Delay(1000);

                Servicios service = new Servicios();
                int responseServer = service.Registro(users);
                _loading.IsVisible = false;
                if (responseServer == 0) return;
                if (responseServer==1)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new CREAPrincipalPage());
                    Application.Current.MainPage.Navigation.RemovePage(this);


                }
                else
                {
                    await DisplayAlert("Notificación", "El Correo ya exite en la aplicación", "Aceptar");
                    return;
                }


            }
        }

        public void DesactivarCampos()
        {
            EntNombre.IsEnabled = EntApellido.IsEnabled = EntCedula.IsEnabled = EntCorreo.IsEnabled = EntPassword.IsEnabled = EntVePassword.IsEnabled = false;
        }
    }
}