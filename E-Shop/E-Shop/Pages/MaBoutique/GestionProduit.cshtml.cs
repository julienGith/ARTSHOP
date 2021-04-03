using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique
{
    public class GestionProduitModel : PageModel
    {
        public List<Entities.Categorie> CatParents { get; set; }
        public List<Entities.Categorie> Catenfants1 { get; set; }
        public List<Entities.Categorie> Catenfants2 { get; set; }

        public void OnGet()
        {

        }
    }
}
