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
        public int quantity { get; set; }
        public Format format { get; set; }
        public decimal? price
        {
            get
            {
                return this.format.Prix - (this.format.Prix * this.produit.Rabais / 100) * this.quantity;
            }
        }
    }
    public class Cart
    {
        public Cart()
        {
            items = new HashSet<Item>();
        }

        public virtual ICollection<Item> items { get; set; }

    }
}
