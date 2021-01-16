using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Entities;
using DataLayerCSV;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace GN_Gestione
{
    public partial class CercaCliente : ContentPage

    {
        //public IList<Cliente_Retail> IPrintList { get; private set; }
        public ObservableCollection<Cliente_Retail> ClientiCollection { get; set; }
        List<Cliente_Retail> PrintList = new List<Cliente_Retail>();


        public ObservableCollection<List<string>> HeadersCollection = new ObservableCollection<List<string>>();
        List<string> PrintHeaders = new List<string>();

        List<Cliente_Retail> tempdata = new List<Cliente_Retail>();



        public CercaCliente()
        {
            InitializeComponent();
         

            PrintHeaders = GetHeaders();

            HeadersCollection.Clear();
            List<string> ercazzo = new List<string>();


            foreach (string str in PrintHeaders)
            {
                ercazzo.Add(str);
            }

            HeadersCollection.Add(ercazzo);


            HeadersView.ItemsSource = HeadersCollection;


            PrintList = GetLista();
            int z = PrintList.Count;

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


        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var customer = (Cliente_Retail)button.CommandParameter;
            if (customer == null) return;
            await Navigation.PushAsync(new ModificaCliente(customer));

        }

       private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            PrintList = GetLista();
            int z = PrintList.Count;

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
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ClientiView.ItemsSource = ClientiCollection;
            }

            else
            {
                ClientiView.ItemsSource = ClientiCollection.Where(x => x.Cl_Ret_Name.StartsWith(e.NewTextValue));
            }
        }

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
