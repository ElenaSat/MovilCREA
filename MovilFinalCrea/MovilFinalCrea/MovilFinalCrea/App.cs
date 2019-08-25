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
        public static List<Models.clsEmpresa> ListEmpresa;
        public static List<Models.clsUsers> ListUsers;
        public App ()
		{
            ListCategoriaEmp = new List<Models.clsCategoriaEmpresa>();
            ListEmpresa = new List<Models.clsEmpresa>();
            ListUsers = new List<Models.clsUsers>();
           

            //MainPage = new NavigationPage(new CREAPrincipalPage());
            MainPage = new NavigationPage(new CREAPerfilEmpresaPage());
            //MainPage = new NavigationPage(new CREARegistroPage());
            // MainPage = new  CREARegistroPage();
            

        }
	}
}