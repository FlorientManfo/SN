using SignaturePad.Forms;
using SN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailLiraision : ContentPage
    {
        private Livraison livraison = null;

        public DetailLiraision(Livraison livraison)
        {
            InitializeComponent();

            this.livraison = livraison;
        }

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            Stream stream = await signature.GetImageStreamAsync(SignatureImageFormat.Jpeg);
            if(stream != null)
            {
                livraison.Statut = true;
                App.livraisons.Remove(livraison);
                await DisplayAlert("Alert", "Save done!", "OK");
                _ = Navigation.PopModalAsync(true);
            }
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }

        protected override void OnAppearing()
        {
            Reference.Text = livraison.Reference;
            Date.Text = livraison.Date.ToString();
            Lieu.Text = livraison.Lieu;
            Client.Text = livraison.Client;
            Telephone.Text = livraison.Telephone.ToString();
            base.OnAppearing();
        }
    }
}