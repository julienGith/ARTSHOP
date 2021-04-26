using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Models
{
    public class MenuCat
    {
        public MenuCat()
        {
            CatParentsAlim = new HashSet<Categorie>();
            CatEnfants1 = new HashSet<Categorie>();
            CatEnfants2 = new HashSet<Categorie>();

        }
        public ICollection<Categorie> CatParentsAlim;
        public ICollection<Categorie> CatEnfants1 ;
        public ICollection<Categorie> CatEnfants2;
    }
}
