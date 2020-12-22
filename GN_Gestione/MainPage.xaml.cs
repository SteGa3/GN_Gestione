﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace GN_Gestione
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer




    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void GoToListAll(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaClienti());

        }


        private async void GoToAddRetailCustomer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inserisci_Cliente());

        }

        /*private async void GoToSearchCustomer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CercaCliente());

        } */
    }
}
