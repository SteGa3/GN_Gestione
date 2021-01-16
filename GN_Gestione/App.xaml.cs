using System;
using Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GN_Gestione
{
    public partial class App : Application
    {
        private static AppSettings appSettings = new AppSettings();
        //file path
        //Check if file exists
        //Write settings on object

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());
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
