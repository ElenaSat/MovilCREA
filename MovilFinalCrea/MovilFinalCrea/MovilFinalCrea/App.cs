using MovilFinalCrea.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MovilFinalCrea
{
	public class App : Application
	{
        public static List<Models.clsCategoriaEmpresa> ListCategoriaEmp;

        public App ()
		{
            ListCategoriaEmp = new List<Models.clsCategoriaEmpresa>();

            MainPage = new NavigationPage(new CREAPrincipalPage());
        }
	}
}