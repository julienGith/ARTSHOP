using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.BoutiqueLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.GestionBoutique
{
    public class DescriptionModel : PageModel
    {
        private BoutiqueLogic boutiqueLogic = new BoutiqueLogic();
        public int boutiqueId { get; set; }
        Entities.Boutique boutique = new Entities.Boutique();
        [BindProperty]
        public Input input { get; set; }
        public class Input
        {
            [Required]
            [StringLength(500)]
            [Display(Name = "Description courte")]
            public string BDescriptionC { get; set; }
            [Required]
            [StringLength(4000)]
            [Display(Name = "Description Longue")]
            public string BDescriptionL { get; set; }

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                boutique.BDescriptionC = input.BDescriptionC;
                boutique.BDescriptionL = input.BDescriptionL;
                await boutiqueLogic.UpdateBoutique(boutique);
                return Redirect("/MaBoutique/GestionBoutique/GestionBoutique");
            }
            return Page();
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("btqId")>0)
            {
                boutiqueId = HttpContext.Session.Get<int>("btqId");
                boutique = await boutiqueLogic.GetBoutiqueById(boutiqueId);
                input.BDescriptionC = boutique.BDescriptionC;
                input.BDescriptionL = boutique.BDescriptionL;
            }
            return Page();
        }
    }
}
