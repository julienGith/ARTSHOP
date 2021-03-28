using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    public partial class UserToken
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public string LoginProvider { get; set; }
        [Key]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
