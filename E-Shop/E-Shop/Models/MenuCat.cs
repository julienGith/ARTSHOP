using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Models
{
    public class CatSubCat
    {
        public CatSubCat()
        {
            catEnfants = new HashSet<Categorie>();
            subCats = new HashSet<Categorie>();
        }
        public Categorie catParent { get; set; }
        public ICollection<Categorie> catEnfants { get; set; }
        public ICollection<Categorie> subCats { get; set; }

    }
    public class MenuCat
    {
        public MenuCat()
        {
            CatParentsAlim = new HashSet<Categorie>();
            CatEnfants1 = new HashSet<Categorie>();
            CatEnfants2 = new HashSet<Categorie>();
            CatSubCats = new HashSet<CatSubCat>();

        }
        public ICollection<CatSubCat> CatSubCats { get; set; }
        public ICollection<Categorie> CatParentsAlim;
        public ICollection<Categorie> CatEnfants1 ;
        public ICollection<Categorie> CatEnfants2;
    }
}
