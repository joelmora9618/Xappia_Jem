using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Xappia_Jem
{
    public partial class App : Application
    {
        public static String RutaDB;
        public App()
        {
            InitializeComponent();

            MainPage = new Xappia_Jem.MainPage();
        }

        public App(String rutaDb)
        {
            InitializeComponent();

            RutaDB = rutaDb;

            MainPage = new NavigationPage(new Xappia_Jem.MainPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
