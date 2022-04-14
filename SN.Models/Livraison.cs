using System;

namespace SN.Models
{
    public class Livraison
    {
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public string Lieu { get; set; }
        public bool Statut { get; set; }
        public string Client { get; set; }
        public long Telephone { get; set; }

        public Livraison() { Statut = false; }

        public Livraison(string reference, DateTime date, string lieu, string client, long telephone)
        {
            Reference = reference;
            Date = date;
            Lieu = lieu;
            Client = client;
            Telephone = telephone;
        }

        public override bool Equals(object obj)
        {
            return obj is Livraison livraison &&
                   Reference == livraison.Reference;
        }
    }
}
