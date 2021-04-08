using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic.LivraisonTypeLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Pages.MaBoutique.LivraisonType
{
    public class EditLivraisonTypeModel : PageModel
    {
        private LivraisonTypeLogic livraisonTypeLogic = new LivraisonTypeLogic();
        public Livraisontype livraisonType = new Livraisontype();
        public int Btqid { get; set; }
        public int lvrTypeId { get; set; }

        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public Input input { get; set; }
        public class Input
        {
            [Required]
            [Display(Name = "Type de livraison")]
            public string Designation { get; set; }
            [Required]
            [Display(Name = "Délai de livraison en jour")]
            public short? LvrDelai { get; set; }
            [Required]
            [Display(Name = "Coût fixe de la livraison")]
            public decimal? LvrCout { get; set; }
            [Required]
            [Display(Name = "Coût par kilogramme supplémentaire")]
            public decimal? LvrCoutPsup { get; set; }
        }
        public async Task<IActionResult> OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                if (lvrTypeId>0)
                {
                    await livraisonTypeLogic.UpdateLivraisonType(lvrTypeId, input.Designation, input.LvrDelai, input.LvrCout, input.LvrCoutPsup);
                }
                else
                {
                    await livraisonTypeLogic.AddLivraisonType(Btqid, input.Designation, input.LvrDelai, input.LvrCout, input.LvrCoutPsup);
                }
            }
            return RedirectToPage("/MaBoutique/Produit/GestionLivraisonType");

        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/MaBoutique/Produit/TableauDeBord");

        }

        public async Task<IActionResult> OnGet()
        {
            Options = new List<SelectListItem> {

            new SelectListItem { Value = "1", Text = "Livraison gratuite, La Poste" },
            new SelectListItem { Value = "2", Text = "Livraison gratuite, Mondial Relais" },
            new SelectListItem { Value = "3", Text = "Livraison gratuite, ChronoFresh" },
            new SelectListItem { Value = "4", Text = "ChronoFresh" },
            new SelectListItem { Value = "5", Text = "La Poste" },
            new SelectListItem { Value = "6", Text = "Mondial Relais" },
            new SelectListItem { Value = "7", Text = "Point Relais" }

            };
            if (HttpContext.Session.Get<int>("btqId")>0)
            {
                Btqid = HttpContext.Session.Get<int>("btqId");

            }
            if (HttpContext.Session.Get<int>("lvrTypeId")>0)
            {
                lvrTypeId = HttpContext.Session.Get<int>("lvrTypeId");
                livraisonType = await livraisonTypeLogic.GetLivraisonTypeById(lvrTypeId);
                input.Designation = livraisonType.Lvrdesignation;
                input.LvrCout = livraisonType.Lvrcout;
                input.LvrCoutPsup = livraisonType.LvrcoutPsup;
                input.LvrDelai = livraisonType.Lvrdelai;
            }
            return Page();

        }
    }
}
