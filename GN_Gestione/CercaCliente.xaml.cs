using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Entities;

using Xamarin.Forms;

namespace GN_Gestione
{
    public partial class CercaCliente : ContentPage
    {
        public ObservableCollection<Cliente_Retail> ClientiCollection { get; set; }
        List<Cliente_Retail> PrintList = new List<Cliente_Retail>();


        public ObservableCollection<List<string>> HeadersCollection = new ObservableCollection<List<string>>();
        List<string> PrintHeaders = new List<string>();

        public CercaCliente()
        {


            InitializeComponent();

            PrintHeaders = GetHeaders();
            HeadersCollection.Clear();
            List<string> peeb = new List<string>();


            foreach (string str in PrintHeaders)
            {

                peeb.Add(str);

            }
            HeadersCollection.Add(peeb);


            HeadersView.ItemsSource = HeadersCollection;


            PrintList = GetLista();
            int z = PrintList.Count();

            ObservableCollection<Cliente_Retail> ClientiCollection = new ObservableCollection<Cliente_Retail>();
            ClientiCollection.Clear();

            if (z != 0)
            {
                foreach (Cliente_Retail cliente in PrintList)
                {
                    ClientiCollection.Add(cliente);
                }
            }

            else
            {
                ClientiCollection.Add(new Cliente_Retail { Cl_Ret_Name = "Lista vuota" });
            }

            ClientiView.ItemsSource = ClientiCollection;

        }


        /*   private async void Button_Clicked(object sender, EventArgs e, SelectedItemChangedEventArgs obj)
           {

               var selectedCustomer = obj.SelectedItem as Cliente_Retail;
               int index = selectedCustomer.Cl_Ret_CODE;
               //await Navigation.PushAsync(new Page2(selectedInstructor.Id));
               await Navigation.PushAsync(new ModificaCliente(index));



           } */

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var customer = (Cliente_Retail)button.CommandParameter;
            if (customer == null) return;



            await Navigation.PushAsync(new ModificaCliente(customer));

        }





        /*protected override void OnAppearing()
        {
            base.OnAppearing();

            
           
        } */



        public List<string> GetHeaders()
        {
            ClienteRetailCSVDataLayer clienteRetailCSVDataLayer = new ClienteRetailCSVDataLayer();
            return clienteRetailCSVDataLayer.GetAllHeaders();
        }

        public List<Cliente_Retail> GetLista()
        {
            ClienteRetailCSVDataLayer clienteRetailCSVDataLayer = new ClienteRetailCSVDataLayer();
            return clienteRetailCSVDataLayer.GetAllRetail();
        }









    }
}
