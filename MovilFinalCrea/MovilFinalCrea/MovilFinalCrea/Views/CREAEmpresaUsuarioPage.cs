using MovilFinalCrea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MovilFinalCrea.Views
{
    public class CREAEmpresaUsuarioPage : ContentPage
    {
        Image Logoimage = null;
        Label LbId = null, LbEmpNombre = null, LbEmpTelefonos = null, LbEmpDireccion = null,
        LbEmpDescripcion = null, LbEmpCategoria = null,  LbUsuario=null; //LbEmpLatitud = null, LbEmpLongitud = null,
       
        public CREAEmpresaUsuarioPage(clsEmpresa obclsEmpresa)
        {

            this.BackgroundColor = Color.White;
            LbId = new Label
            {
                Text =Convert.ToString(obclsEmpresa.PK_Emp_Id),
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                IsVisible = false// Me oculta el id
            };
            LbEmpNombre = new Label
            {
                Text = obclsEmpresa.Emp_Nombre,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };
            LbEmpTelefonos = new Label
            {
                Text = "Número de Contacto: "+ obclsEmpresa.Emp_Telefonos,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold
            };
            LbEmpDireccion = new Label
            {
                Text = "Dirección: "+obclsEmpresa.Emp_Direccion,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold
            };
            LbEmpDescripcion = new Label
            {
                Text = "Descripción: "+obclsEmpresa.Emp_Descripcion,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold
            };
            LbEmpCategoria = new Label
            {
                Text = "Categoria: "+obclsEmpresa.Categoria_Empresa.Descripcion,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold
            };
            LbUsuario = new Label
            {
                Text = "Gerente: "+obclsEmpresa.Users.UserName+" "+ obclsEmpresa.Users.UserLastName,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold
            };
            Logoimage = new Image
            {
                Source = ImageSource.FromFile("empresa.png"),
                WidthRequest = 80,
                HeightRequest = 80
            };

            var rating = new RatingStars();
            rating.SetBinding(RatingStars.RatingProperty, "Rating");
            rating.SetBinding(RatingStars.ReviewsProperty, "Reviews");

            StackLayout stack = new StackLayout
            {
                Padding = new Thickness(12, 12, 12, 12),
                Margin = new Thickness(12, 12, 12, 12),
                BackgroundColor = Color.White,

            };
            stack.Children.Add(LbId);
            stack.Children.Add(Logoimage);
            stack.Children.Add(LbEmpNombre);
            stack.Children.Add(LbUsuario);
            stack.Children.Add(LbEmpDireccion);
            stack.Children.Add(LbEmpTelefonos);
            stack.Children.Add(LbEmpCategoria);
            stack.Children.Add(LbEmpDescripcion);
            stack.Children.Add(rating);

            Content = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical, // ScrollOrientation.Horizontal
                Content = stack

            };


        }
    }
}