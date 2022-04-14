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
        public App()
        {
            InitializeComponent();
            List<Livraison> livraisions = null;

            var json = SecureStorage.GetAsync("Livraisions").Result;
            if (!string.IsNullOrEmpty(json))
            {
                var livraisonsInitiales = JsonConvert.DeserializeObject<List<Livraison>>(json);
                livraisions = livraisonsInitiales.FindAll(x => x.Statut == false);
            }
            else
            {
                livraisions = new List<Livraison>
                {
                    new Livraison("Ordinateurs",DateTime.Now, "Douala", "SN", 6777777777),
                    new Livraison("Ordinateurs",DateTime.Now, "Douala", "SN", 6777777777),
                    new Livraison("Ordinateurs",DateTime.Now, "Douala", "SN", 6777777777),
                    new Livraison("Ordinateurs",DateTime.Now, "Douala", "SN", 6777777777)
                };
            }

            MainPage = new NavigationPage(new MainPage(livraisions));
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
