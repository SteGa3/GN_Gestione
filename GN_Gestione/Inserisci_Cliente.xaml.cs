using System;
using Entities;
using DataLayerCSV;
using System.Collections.Generic;
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

        

        private async void GoToAggiungiCliente(object sender, EventArgs e)
        {
            Cliente_Retail cli = new Cliente_Retail();
            cli.Cl_Ret_Name = nome.Text;
            cli.Cl_Ret_Nickname = soprannome.Text;
            cli.Cl_Ret_CODE = 0;
            cli.Cl_Ret_Act = 0;
            cli.Cl_Ret_Tot = 0;
            cli.Cl_Ret_Comment = commento.Text;
            ClienteRetailCSVDataLayer clienteRetailCSVDataLayer = new ClienteRetailCSVDataLayer();
            var check = clienteRetailCSVDataLayer.InsRetailCSV(cli);
            //string[] array = Enum.GetValues(string (ClienteRetailCSVDataLayer.DelResultsCodes);
            



            
            await Navigation.PushAsync(new MainPage());


        }

    }

  


}

