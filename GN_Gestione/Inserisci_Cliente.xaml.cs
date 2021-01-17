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
        private async void GoToAggiungiCliente(object sender, EventArgs e)
        {
            Cliente_Retail cli = new Cliente_Retail();
            cli.Cl_Ret_Name = nome.Text;
            cli.Cl_Ret_Nickname = soprannome.Text;
            cli.Cl_Ret_CODE = 0;
            cli.Cl_Ret_Act = 0;
            cli.Cl_Ret_Tot = 0;
            cli.Cl_Ret_Comment = "";
            

            
            InserisciCliente(cli);
            await Navigation.PushAsync(new MainPage());


        }

    }

  


}

