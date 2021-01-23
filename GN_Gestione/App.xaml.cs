using System;
using System.IO;
using Entities;
using DatalayerCSV;
using FileManager;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCLStorage;

namespace GN_Gestione
{
    public partial class App : Application
    {

        private static AppSettings appSettings = new AppSettings();
        private static IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;
        private static FileManager.DeviceIO fileManager = new FileManager.DeviceIO();
        private static readonly string settingsFolder = "settings";
        private static readonly string settingsName = "mainsettings.csv";
        private static readonly string devicePath = rootFolder.Path.ToString();
        private static readonly string settingsPath = settingsFolder + "/" + settingsName;
        private string fullPath = devicePath + "/" + settingsFolder + "/" + settingsName;
        
        public App()
        {
            InitializeComponent();
            SettingsCheck();

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

        private bool FileExists(string _path)
        {
            DeviceIO device = new DeviceIO();
            return device.FileExists(_path);
        }

        private void SettingsCheck()
        {
            var c = fileManager.FileExists(settingsPath);

            if (!c)
            {
                fileManager.CreateFolder(settingsFolder);
                fileManager.CreateFile(settingsFolder + "/" + settingsName);
                MainPage = new NavigationPage(new Impostazioni());
            }

            else
            { 
                //carica appSettings da file csv
                MainPage = new NavigationPage(new MainPage());
            }
        }
    }
}
