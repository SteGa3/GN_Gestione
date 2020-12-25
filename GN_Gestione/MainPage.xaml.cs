using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using DataLayerCSV;
using PCLStorage;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GN_Gestione
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer




    public partial class MainPage : ContentPage
    {
        public string FileName="ListaClienti.csv";
        public DataLayerCSV.FileManagerCSVDataLayer DataManagement = new FileManagerCSVDataLayer();
        public string MyProperty = "not checked";
        StackLayout parent;


        public MainPage()
        {
            InitializeComponent();
            bool isExt = true;

            isExt = Existance(FileName);
            if (isExt == true)
            {
                MyProperty = "esiste";
            }
            else
            {

                MyProperty = "non esiste."; 
                Button button = new Button { Text = "Crea File" };
                Layout.Children.Add(button);
                /*

                // Creating a binding
                newButton.SetBinding(Button.CommandProperty, new Binding("ViewModelProperty"));

                // Set the binding context after SetBinding method calls for performance reasons
                newButton.BindingContext = Layout;

                // Set StackLayout in XAML to the class field
                parent = Layout; */

            }

            
            StatoFile.Text = FileName + "  " + MyProperty;

        }

        //File Manager DataLayer

        public bool Existance(string _filename)
        {
            FileManagerCSVDataLayer g = new FileManagerCSVDataLayer();
            var check = g.FileExists(_filename);
            return check;
        }

        public void Addbutton(object sender, EventArgs e)
        {
            // Define a new button
            Button newButton = new Button { Text = "Crea File" };

            // Creating a binding
            newButton.SetBinding(Button.CommandProperty, new Binding("ViewModelProperty"));

            // Set the binding context after SetBinding method calls for performance reasons
            newButton.BindingContext = Layout;

            // Set StackLayout in XAML to the class field
            parent = Layout;

            // Add the new button to the StackLayout
            parent.Children.Add(newButton);
        }


        //Link to pages
        private async void GoToListAll(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaClienti());

        }


        private async void GoToAddRetailCustomer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inserisci_Cliente());

        }

        private async void GoToSearchCustomer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CercaCliente());

        }
    }
}
