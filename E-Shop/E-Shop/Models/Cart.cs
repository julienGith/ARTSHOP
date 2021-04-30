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
    }
    public class Cart
    {
        public Cart()
        {
            items = new HashSet<Item>();
        }
        public decimal? prixTotal
        {
            get
            {
                return items.Sum(i => i.price);
            }
        }
        public virtual ICollection<Item> items { get; set; }

    }
}
