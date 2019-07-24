using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MovilFinalCrea.Views
{
	public class CREANosotrosPage : ContentPage
	{
        Label lbInfoQuienesSomos = null, lbMision = null, lbVision = null, lbInfoTitulo1 = null, lbInfoTitulo2 = null, lbInfoTitulo3 = null;
        Button btnValores = null;
        public CREANosotrosPage ()
		{
            this.BackgroundColor = Color.White;
             lbInfoTitulo1 = new Label()
            {
                TextColor = Color.FromHex("#695776"),
                Text = "¿QUIÉNES SOMOS?",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center
            };
             lbInfoQuienesSomos = new Label
            {
                TextColor = Color.Black,
                Text = "Somos una Comunidad de Emprendedores altamente Recomendados, " +
                       "liderados por un staff de Consultores Master Certificados; Nuestro principal interés es el crecimiento y desarrollo de la capacidad social y productiva de los emprendimientos que hacen parte de ella." +
                       "A partir del relacionamiento, el trabajo colaborativo, la socialización del conocimiento y regidos bajo nuestros valores buscamos generar beneficios que impacten a sus miembros y se extiendan a nuestra sociedad.",
                FontAttributes = FontAttributes.Italic,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,

            };
             lbInfoTitulo2 = new Label()
            {
                TextColor = Color.FromHex("#695776"),
                Text = "MISIÓN CREA",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center
            };
             lbMision = new Label
            {
                TextColor = Color.Black,
                Text = "Empoderar a los emprendedores y sus emprendimientos a través de mentorías, " +
                       "asesorías o acompañamientos, impactando sus procesos, productos y personas para llevarlos a un crecimiento sostenible y escalable," +
                       " apalancados en una comunidad inspiracional guiada bajo los principios de la economía solidaria.",
                FontAttributes = FontAttributes.Italic,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,

            };
             lbInfoTitulo3 = new Label()
            {
                TextColor = Color.FromHex("#695776"),
                Text = "VISIÓN CREA",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center
            };
             lbVision = new Label
            {
                TextColor = Color.Black,
                Text = "visión pendiente",
                FontAttributes = FontAttributes.Italic,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,

            };
             btnValores = new Button
            {
                Text = "VALORES",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#695776"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                CornerRadius = 1,
                
            };

            var stack = new StackLayout
            {
                Padding = new Thickness(12, 12, 12, 12),
                Margin = new Thickness(12, 12, 12, 12),
                BackgroundColor = Color.White,

            };

            btnValores.Clicked += BtnValores_Clicked;
            stack.Children.Add(lbInfoTitulo1);
            stack.Children.Add(lbInfoQuienesSomos);
            stack.Children.Add(lbInfoTitulo2);
            stack.Children.Add(lbMision);
            stack.Children.Add(lbInfoTitulo3);
            stack.Children.Add(lbVision);
            stack.Children.Add(btnValores);

            Content = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical, // ScrollOrientation.Horizontal
                Content = stack

            };

        }

        public async void BtnValores_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new CREAPrincipalPage()));
            Navigation.RemovePage(this);
        }
    }
}