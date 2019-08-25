using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MovilFinalCrea.Views
{
	public class ViewCellEmpresaPage : ViewCell
    {
        Label LbId = null, LbEmpNombre = null, LbEmpTelefonos = null, LbEmp_Direccion = null;
      
        Image Logoimage = null;
        public ViewCellEmpresaPage ()
		{
            StackLayout ViewGeneral = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Transparent
            };

            StackLayout ViewText = new StackLayout
            {
                BackgroundColor = Color.Transparent,
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
            };

            LbId = new Label
            {
                Text = "",
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                IsVisible = false// Me oculta el id
            };
            LbEmpNombre = new Label
            {
                Text = "",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };
            LbEmpTelefonos = new Label
            {
                Text = "",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold
            };
            LbEmp_Direccion = new Label
            {
                Text = "",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold
            };
            Logoimage = new Image {
                Source = ImageSource.FromFile("empresa.png"),
                WidthRequest = 60,
                HeightRequest = 60
            };

            LbId.SetBinding(Label.TextProperty, new Binding("PK_Emp_Id"));
            LbEmpNombre.SetBinding(Label.TextProperty, new Binding("Emp_Nombre"));
            LbEmpTelefonos.SetBinding(Label.TextProperty, new Binding("Emp_Telefonos"));
            LbEmp_Direccion.SetBinding(Label.TextProperty, new Binding("Emp_Direccion"));

            ViewText.Children.Add(LbId);
            ViewText.Children.Add(LbEmpNombre);
            ViewText.Children.Add(LbEmpTelefonos);
            ViewText.Children.Add(LbEmp_Direccion);

            ViewGeneral.Children.Add(Logoimage);
            ViewGeneral.Children.Add(ViewText);

            View = ViewGeneral;

        }
	}
}