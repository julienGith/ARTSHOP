﻿using ShopWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Models
{
    public class CartItemViewModel
    {
        public Produit Produit { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
