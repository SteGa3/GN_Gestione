using System;
using System.Collections.Generic;
using DataLayerCSV;
using Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;


using DatalayerCSV;
using System.IO;
using Xamarin.Forms.Xaml;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Data;
using System.Globalization;
using Microsoft.VisualBasic;



using Xamarin.Forms;

namespace GN_Gestione
{
    public partial class ModificaCliente : ContentPage
    {
        Cliente_Retail cl = new Cliente_Retail();
        public ObservableCollection<Cliente_Retail> ClientiCollection { get; set; }
        
  

        public ModificaCliente(Cliente_Retail cliente)
        {
            InitializeComponent();
            ObservableCollection<Cliente_Retail> ClientiCollection = new ObservableCollection<Cliente_Retail>();
            ClientiCollection.Clear();

            if (cliente != null)
            {
                ClientiCollection.Add(cliente);

                
            }

            else //si potrebbe inserire exception
            {
                ClientiCollection.Add(new Cliente_Retail { Cl_Ret_Name = "Errore Passaggio Dati" });

                
            }
            ClienteModView.ItemsSource = ClientiCollection;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
