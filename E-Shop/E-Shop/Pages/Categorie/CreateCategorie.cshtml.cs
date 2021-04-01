using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.Categorie
{
    public class CreateCategorieModel : PageModel
    {
        public Input input { get; set; }
        public class Input
        {
            public string CatNom { get; set; }
            ICollection<Categorie> Categories { get; set; }
        }
        public void OnGet()
        {
        }
    }
}
