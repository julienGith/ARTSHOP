using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Logic.LivraisonTypeLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Pages.MaBoutique.LivraisonType
{
    public class EditLivraisonTypeModel : PageModel
    {
        private LivraisonTypeLogic livraisonTypeLogic = new LivraisonTypeLogic();
        public int MyProperty { get; set; }
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public Input input { get; set; }
        public class Input
        {
            public string Designation { get; set; }
            public short LvrDelai { get; set; }
            public decimal LvrCout { get; set; }
            public decimal LvrCoutPsup { get; set; }
            public int Btqid { get; set; }
        }
        public async Task<IActionResult> OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                await livraisonTypeLogic.AddLivraisonType(input.Btqid, input.Designation, input.LvrDelai, input.LvrCout, input.LvrCoutPsup);
            }
            return Page();

        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/MaBoutique/Produit/TableauDeBord");

        }

        public void OnGet()
        {
            Options = new List<SelectListItem> {

            new SelectListItem { Value = "1", Text = "Livraison gratuite, La Poste" },
            new SelectListItem { Value = "2", Text = "Livraison gratuite, Mondial Relais" },
            new SelectListItem { Value = "3", Text = "Livraison gratuite, ChronoFresh" },
            new SelectListItem { Value = "4", Text = "ChronoFresh" },
            new SelectListItem { Value = "5", Text = "La Poste" },
            new SelectListItem { Value = "6", Text = "Mondial Relais" }

            };

        }
    }
}
