using SN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SN
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            Loader.IsVisible = true;

            var livraisons = App.livraisons.FindAll(x => x.Statut == false);
            CvLivraison.ItemsSource = livraisons;
            base.OnAppearing();

            Loader.IsVisible = false;
        }

        private void Refresh_Refreshing(object sender, EventArgs e)
        {
            Refresh.IsRefreshing = false;
            OnAppearing();
        }
        private async void CvLivraision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var livraison = CvLivraison.SelectedItem as Livraison;
            if (livraison != null)
                await Navigation.PushModalAsync(new DetailLiraision(livraison));
        }
    }
}
