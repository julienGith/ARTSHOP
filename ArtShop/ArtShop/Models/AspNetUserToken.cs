using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class AspNetUserToken
    {
        public int UserId { get; set; }
        public int LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
