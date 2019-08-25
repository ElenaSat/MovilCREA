using MovilFinalCrea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MovilFinalCrea.Views
{
    public class CREAPerfilEmpresaPage : ContentPage
    {
        Image Logoimage = null;
        Entry EntEmpNombre = null, EntEmpTelefonos = null, EntEmpDireccion = null,
        EntEmpDescripcion = null, EntEmpLatitud = null, EntEmpLongitud = null, EntPalabrasClaves = null;
        private Map mapa;
       // Pin pin;

        Button BtnAgregar = null, BtnEditar = null, BtnEliminar = null;
        public CREAPerfilEmpresaPage()
        {
            this.BackgroundColor = Color.FromHex("#EDE7E1");
            Logoimage = new Image
            {
                Source = ImageSource.FromFile("empresa.png"),
                WidthRequest = 60,
                HeightRequest = 60
            };

            EntEmpNombre = new Entry()
            {
                Placeholder = "Nombre de la Empresa",
                FontSize = 14,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Start,
                Keyboard = Keyboard.Text,
                PlaceholderColor= Color.FromHex("004f6d"),
            };
            EntEmpTelefonos = new Entry()
            {
                Placeholder = "Número de Contacto",
                FontSize = 14,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Start,
                Keyboard = Keyboard.Telephone,
                PlaceholderColor = Color.FromHex("004f6d"),
            };
            EntEmpDireccion = new Entry()
            {
                Placeholder = "Dirección",
                FontSize = 14,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Start,
                Keyboard = Keyboard.Text,
                PlaceholderColor = Color.FromHex("004f6d"),
            };
            EntEmpDescripcion = new Entry()
            {
                Placeholder = "Descripción",
                FontSize = 14,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Start,
                Keyboard = Keyboard.Text,
                PlaceholderColor = Color.FromHex("004f6d"),
            };
            EntPalabrasClaves = new Entry()
            {
                Placeholder = "Ingrese las palabras claves separadas por una (,)",
                FontSize = 14,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Start,
                Keyboard = Keyboard.Text,
                PlaceholderColor = Color.FromHex("004f6d"),
            };
            EntEmpLatitud = new Entry()
            {
                Placeholder = "Latitud",
                FontSize = 14,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Start,
                Keyboard = Keyboard.Numeric,
                PlaceholderColor = Color.FromHex("004f6d"),
            };
            EntEmpLongitud = new Entry()
            {
                Placeholder = "Longitud",
                FontSize = 14,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Start,
                Keyboard = Keyboard.Numeric,
                PlaceholderColor = Color.FromHex("004f6d"),
            };

            Label lbOpciones = new Label()
            {
                TextColor = Color.FromHex("004f6d"),
                Text = "Selecciona una opción:",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Label lbubicacion = new Label()
            {
                TextColor = Color.FromHex("004f6d"),
                Text = "Ubicación Geográfica",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Label lbDatos = new Label()
            {
                TextColor = Color.FromHex("004f6d"),
                Text = "Información de la Empresa",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center
            };

            mapa = new Map(
                MapSpan.FromCenterAndRadius(new Position(3.4332325, -76.4910089), Distance.FromMiles(0.3))){ 
                IsShowingUser = false,//posicion del usuario
                HeightRequest = 360,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType=MapType.Street,
                
            };
            //
           

            //Botones
            BtnAgregar = new Button
            {
                Text = "Agregar",
                TextColor = Color.FromHex("#ede7e1"),
                BackgroundColor = Color.FromHex("#004f6d"),
                FontAttributes = FontAttributes.Bold,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                CornerRadius = 1,
            };
            BtnEditar = new Button
            {
                Text = "Editar",
                TextColor = Color.FromHex("#ede7e1"),
                BackgroundColor = Color.FromHex("#004f6d"),
                FontAttributes = FontAttributes.Bold,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                CornerRadius = 1,
            };
            BtnEliminar = new Button
            {
                Text = "Eliminar",
                TextColor = Color.FromHex("#ede7e1"),
                BackgroundColor = Color.FromHex("#004f6d"),
                FontAttributes = FontAttributes.Bold,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                CornerRadius = 1,

            };
            //Metodos de botones
            BtnAgregar.Clicked += BtnAgregar_Clicked;
            BtnEditar.Clicked += BtnEditar_Clicked;
            BtnEliminar.Clicked += BtnEliminar_Clicked;
            //StackLayout
            StackLayout Registro = new StackLayout
            {
                Padding = new Thickness(12, 12, 12, 12),
                Margin = new Thickness(12, 12, 12, 12),
                BackgroundColor = Color.FromHex("#EDE7E1"),

            };

            Registro.Children.Add(Logoimage);
            Registro.Children.Add(lbDatos);
            Registro.Children.Add(EntEmpNombre);
            Registro.Children.Add(EntEmpTelefonos);           
            Registro.Children.Add(EntEmpDescripcion);
            Registro.Children.Add(EntPalabrasClaves);
            Registro.Children.Add(lbubicacion);
            Registro.Children.Add(EntEmpDireccion);
            Registro.Children.Add(EntEmpLatitud);
            Registro.Children.Add(EntEmpLongitud);
            Registro.Children.Add(mapa);

            Registro.Children.Add(lbOpciones);

           

            //Botones
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            grid.Children.Add(BtnAgregar, 0, 0);
            grid.Children.Add(BtnEditar, 1, 0);
            grid.Children.Add(BtnEliminar, 2, 0);
           
            Registro.Children.Add(grid);

            Content = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical, // ScrollOrientation.Horizontal
                Content = Registro

            };
        }

        private void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            OpcionesEntryBtn(3);
        }

        private void BtnEditar_Clicked(object sender, EventArgs e)
        {
            OpcionesEntryBtn(2);
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            OpcionesEntryBtn(1);
        }

        private void OpcionesEntryBtn(int opcion)
        {
            switch (opcion)
            {
                
                case 1:
                    //Agregar
                    BtnEditar.IsEnabled = BtnEliminar.IsEnabled = false;
                    break;
                case 2:
                    //Editar
                    BtnAgregar.IsEnabled = BtnEliminar.IsEnabled = false;
                    break;

                case 3:
                    //Eliminar
                    Logoimage.IsEnabled = EntEmpNombre.IsEnabled = EntEmpTelefonos.IsEnabled = EntEmpDireccion.IsEnabled = EntEmpDescripcion.IsEnabled
                        = EntEmpLatitud.IsEnabled = EntEmpLongitud.IsEnabled = EntPalabrasClaves.IsEnabled = false;
                    BtnAgregar.IsEnabled = BtnEditar.IsEnabled = false;
                    break;

            }

        }

    }
}