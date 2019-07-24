using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MovilFinalCrea.Views
{
	public class ViewCellCategoriasPage : ViewCell
	{
		public ViewCellCategoriasPage ()
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


            Label LbDescripcion = new Label
            {
                Text = "",
                FontSize = 12,
                FontAttributes = FontAttributes.Bold
            };

            Label LbId = new Label
            {
                Text = "",
                FontSize = 12,
                FontAttributes = FontAttributes.Bold
            };

            LbDescripcion.SetBinding(Label.TextProperty, new Binding("Descripcion"));
            LbId.SetBinding(Label.TextProperty, new Binding("IdCategoria"));

            ViewText.Children.Add(LbId);
            ViewText.Children.Add(LbDescripcion);
            ViewGeneral.Children.Add(ViewText);

            View = ViewGeneral;
        }
	}
}