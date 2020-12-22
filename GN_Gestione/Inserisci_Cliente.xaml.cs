using System;
using Entities;
using Xamarin.Forms;

namespace GN_Gestione
{
    public partial class Inserisci_Cliente : ContentPage
    {

        public Inserisci_Cliente()
        {
            InitializeComponent();

        }

        private void GoToAggiungiCliente(object sender, EventArgs e)
        {
            Entities.Cliente_Retail cliente_Retail = new Entities.Cliente_Retail();
            cliente_Retail.Cl_Ret_Name = nome.Text;
            cliente_Retail.Cl_Ret_Nickname = soprannome.Text;
            cliente_Retail.Cl_Ret_CODE = Int32.Parse(codice.Text);

            DataLayerCSV.ClienteRetailCSVDataLayer Cli_Send = new DataLayerCSV.ClienteRetailCSVDataLayer();
            Cli_Send.InsRetailCSV (cliente_Retail);
            
            

        }


    }
}
