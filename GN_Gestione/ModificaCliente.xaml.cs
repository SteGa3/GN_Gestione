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
        
        public ObservableCollection<Cliente_Retail> ClientiCollection { get; set; }
        Cliente_Retail cl = new Cliente_Retail();
  

        public ModificaCliente(Cliente_Retail cliente)
        {
            InitializeComponent();
            cl = cliente;

            

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


        private async void GoToAggiungiCliente(object sender, EventArgs e)
        {
            Cliente_Retail cliente_Retail = new Cliente_Retail();

            cliente_Retail.Cl_Ret_CODE = cl.Cl_Ret_CODE;

            if (nome.Text == null) { cliente_Retail.Cl_Ret_Name = cl.Cl_Ret_Name; }
            else {cliente_Retail.Cl_Ret_Name = nome.Text; }

            if (soprannome.Text == null) { cliente_Retail.Cl_Ret_Nickname = cl.Cl_Ret_Nickname; }
            else { cliente_Retail.Cl_Ret_Nickname = soprannome.Text; }

            if (attuale.Text == null) { cliente_Retail.Cl_Ret_Act = cl.Cl_Ret_Act; }
            else { cliente_Retail.Cl_Ret_Act = Convert.ToInt32(attuale.Text); }
                                    
            cliente_Retail.Cl_Ret_Tot = cl.Cl_Ret_Tot;

            if (commento.Text == null) { cliente_Retail.Cl_Ret_Comment = cl.Cl_Ret_Comment; }
            else { cliente_Retail.Cl_Ret_Comment = commento.Text; }
            

            ClienteRetailCSVDataLayer clienteRetailCSVDataLayer = new ClienteRetailCSVDataLayer();
            clienteRetailCSVDataLayer.InsRetailCSV(cliente_Retail);
            await Navigation.PushAsync(new MainPage());

        }

       
    }
}
