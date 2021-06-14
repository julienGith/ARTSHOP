using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Extensions;
using E_Shop.Logic.ProduitLogic;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class DescriptionModel : PageModel
    {
        private ProduitLogic ProduitLogic = new ProduitLogic();
        public Entities.Produit Produit = new Entities.Produit();

        public int prodId { get; set; }

        [BindProperty]
        public Input input { get; set; }
        public class Input
        {
            [Required]
            [StringLength(30)]
            [Display(Name = "Indiquez le nom de votre produit")]
            public string PNom { get; set; }
            [Required]
            [StringLength(500)]
            [Display(Name = "Indiquez une description courte de votre produit")]
            public string PDescriptionC { get; set; }
            [Required]
            [StringLength(4000)]
            [Display(Name = "Indiquez une description longue de votre produit")]
            public string PDescriptionL { get; set; }
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.Get<int>("prodIdUp") > 0)
                {
                    prodId = HttpContext.Session.Get<int>("prodIdUp");
                    Produit = await ProduitLogic.GetProduitById(prodId);
                    Produit.PDescriptionL = input.PDescriptionL;
                    Produit.PDescriptionC = input.PDescriptionC;
                    Produit.PNom = input.PNom;
                    await ProduitLogic.UpdateProduit(Produit);
                }
                HttpContext.Session.Set<Input>("Description", input);
                return RedirectToPage("/MaBoutique/Produit/CaracteristiquesProduit");
            }
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("prodIdUp") > 0)
            {
                prodId = HttpContext.Session.Get<int>("prodIdUp");
                Produit = await ProduitLogic.GetProduitById(prodId);
                input = new Input
                {
                    PDescriptionC = Produit.PDescriptionC,
                    PDescriptionL = Produit.PDescriptionL,
                    PNom = Produit.PNom
                };

            }
            return Page();
        }
    }
}
