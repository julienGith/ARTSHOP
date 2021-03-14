﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Pandetail
    {
        public int Panierid { get; set; }
        public int Prodid { get; set; }
        public short? PQteprod { get; set; }

        public virtual Panier Panier { get; set; }
        public virtual Produit Prod { get; set; }
    }
}