using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Models
{
    public class Item
    {
        public Produit produit { get; set; }
        public string lien { get; set; }
        public int quantity { get; set; }
        public Format format { get; set; }
        public decimal? price
        {
            get
            {
                return (Math.Round((decimal)this.format.Prix, 2) - Math.Round(((decimal)this.format.Prix * ((decimal)this.produit.Rabais/100)), 2)) * (decimal)this.quantity;
            }
        }
        public decimal? weight
        {
            get
            {
                return Math.Round(this.format.Poids ?? (decimal)this.format.Litre, 2) * (decimal)this.quantity;
            }
        }
    }
    public class Btq
    {
        public Btq()
        {
            items = new HashSet<Item>();

        }
        public int itemQuantity
        {
            get
            {
                return items.Sum(i => i.quantity);
            }
        }
        public decimal? ItemsTotalprice
        {
            get
            {
                return items.Sum(i => i.price);
            }
        }
        public decimal? ItemsTotalWeight
        {
            get
            {
                return items.Sum(i => i.weight);
            }
        }
        public int id { get; set; }
        public string nom { get; set; }
        public string lien { get; set; }
        public virtual ICollection<Item> items { get; set; }
        public virtual ICollection<Livraisontype> Livraisontypes { get; set; }

    }
    public class Cart
    {
        public Cart()
        {
            Btqs = new HashSet<Btq>();
        }
        public int quantityTotal
        {
            get
            {
                return Btqs.Sum(i => i.itemQuantity);
            }
        }
        public decimal? prixTotal
        {
            get
            {
                return Btqs.Sum(i => i.ItemsTotalprice);
            }
        }
        public virtual ICollection<Btq> Btqs { get; set; }

    }
}
