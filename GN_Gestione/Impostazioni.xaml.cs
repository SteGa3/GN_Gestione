using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GN_Gestione
{
    public partial class Impostazioni : ContentPage
    {
        public Impostazioni()
        {
            InitializeComponent();
        }

        private async void GoToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
