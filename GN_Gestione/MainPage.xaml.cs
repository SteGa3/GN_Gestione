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
using FileManager;
using PCLStorage;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GN_Gestione
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer




    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public string FileName="ListaClienti.csv";
        private FileManager.DeviceIO DataManagement = new FileManager.DeviceIO();
        private string MyProperty = "not checked";
        private ICommand createFileCommand;
        


        public MainPage()
        {
            InitializeComponent();
            bool isExt = true;

            isExt = DataManagement.FileExists(FileName);

            //isExt = Existance(FileName);
            if (isExt == true)
            {
                MyProperty = "caricato correttamente";
            }
            else
            {

                MyProperty = "non esiste.";

                ICommand createFileCommand;
                Button buttonCreate = new Button { Text = "Crea File" };
                createFileCommand = new Command(createCommand);
                buttonCreate.Command = createFileCommand;
                buttonCreate.BindingContext = createFileCommand;
                buttonCreate.Clicked += Create_Clicked;
                Layout.Children.Add(buttonCreate);

                ICommand deleteFileCommand;
                Button buttonDelete = new Button { Text = "Cancella File" };
                deleteFileCommand = new Command(deleteCommand);
                buttonDelete.BindingContext = deleteFileCommand;
                buttonDelete.Clicked += Delete_Clicked;
                Layout.Children.Add(buttonDelete);







                bool checkCreation = DataManagement.FileExists(FileName);
                if (checkCreation == true)
                {
                    MyProperty = "File Creato.";
                }
                else { MyProperty = "Errore, File non Creato!"; }
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

        //Create new File -> Button
        private void Create_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.IsEnabled = false;
               
            }
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.IsEnabled = false;

            }
        }

        //File Manager DataLayer
        private void createCommand()
        {
            DataManagement.WriteTextFile(FileName);
        }

        private void deleteCommand()
        {

        }

        //Button clicks

        /*void HandleClick(object sender, EventArgs e)
        {
            DataManagement.WriteTextFile(FileName);

        }*/

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
