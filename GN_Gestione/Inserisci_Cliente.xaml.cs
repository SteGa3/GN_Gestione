using System;
using Entities;
using DataLayerCSV;
using Xamarin.Forms;

using System.Collections.ObjectModel;

namespace GN_Gestione
{
    public partial class Inserisci_Cliente : ContentPage
    {

        public Inserisci_Cliente()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void InserisciCliente(Cliente_Retail cliente)
        {
            ClienteRetailCSVDataLayer clienteRetailCSVDataLayer = new ClienteRetailCSVDataLayer();
            clienteRetailCSVDataLayer.InsRetailCSV(cliente);
        }
        private void GoToAggiungiCliente(object sender, EventArgs e)
        {
            Entities.Cliente_Retail cliente_Retail = new Entities.Cliente_Retail();
            cliente_Retail.Cl_Ret_Name = nome.Text;
            cliente_Retail.Cl_Ret_Nickname = soprannome.Text;
            cliente_Retail.Cl_Ret_CODE = 0;
            cliente_Retail.Cl_Ret_Act = 0;
            cliente_Retail.Cl_Ret_Tot = 0;
            cliente_Retail.Cl_Ret_Comment = "";
            cliente_Retail.Cl_Ret_Surname = "";

            DataLayerCSV.ClienteRetailCSVDataLayer Cli_Send = new DataLayerCSV.ClienteRetailCSVDataLayer();
            Cli_Send.InsRetailCSV(cliente_Retail);



        }

    }

  


}

