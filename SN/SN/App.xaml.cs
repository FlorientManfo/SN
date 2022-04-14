using Newtonsoft.Json;
using SN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SN
{
    public partial class App : Application
    {

        public static List<Livraison> livraisons = null;
        public App()
        {
            InitializeComponent();

            var json = SecureStorage.GetAsync("Livraisions").Result;
            if (!string.IsNullOrEmpty(json))
            {
                var livraisonsInitiales = JsonConvert.DeserializeObject<List<Livraison>>(json);
                livraisons = livraisonsInitiales.FindAll(x => x.Statut == false);
            }
            else
            {
                livraisons = new List<Livraison>
                {
                    new Livraison("Ordinateurs1",DateTime.Now, "Douala", "SN", 6777777777),
                    new Livraison("Ordinateurs2",DateTime.Now, "Douala", "SN", 6777777777),
                    new Livraison("Ordinateurs3",DateTime.Now, "Douala", "SN", 6777777777),
                    new Livraison("Ordinateurs4",DateTime.Now, "Douala", "SN", 6777777777)
                };
            }

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
