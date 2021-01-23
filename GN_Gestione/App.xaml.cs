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
        private string settingsPath = devicePath + "/" + settingsFolder + "/" + settingsName;
        
       
        
        
        


        //file path
        //Check if file exists
        //Write settings on object

        public App()
        {
            InitializeComponent();

            var c = fileManager.FileExists(settingsPath);
            fileManager.DeleteFolder("/data");
            if (!c)
            {
                fileManager.CreateFolder(settingsFolder);
                fileManager.CreateFile(settingsFolder + "/" + settingsName);
                //new NavigationPage(new Impostazioni());
            }

            MainPage = new NavigationPage(new MainPage());
            
            
            

                                           
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
    }
}
