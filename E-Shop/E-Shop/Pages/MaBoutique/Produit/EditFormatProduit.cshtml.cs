using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic.FormatLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class EditFormatProduitModel : PageModel
    {
        private FormatLogic FormatLogic = new FormatLogic();
        public int formatId { get; set; }
        public int prodId { get; set; }

        [BindProperty]
        public Input input { get; set; }
        public class Input
        {
            [Display(Name = "Poids du format en grammes")]
            public decimal? poids { get; set; }
            [Display(Name = "Volume du format en litres")]
            public decimal? litre { get; set; }
            [Required]
            [Display(Name = "Prix du format")]
            public decimal? prix { get; set; }

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.Get<int>("formatId")>0)
                {
                    Format format = new Format();
                    format = await FormatLogic.GetFormatById(HttpContext.Session.Get<int>("formatId"));
                    format.Litre = input.litre;
                    format.Poids = input.poids;
                    format.Prix = input.prix;
                    await FormatLogic.UpdateFormat(format);
                    return Redirect("/MaBoutique/Produit/GestionFormatProduit");
                }
                prodId = HttpContext.Session.Get<int>("prodId");
                await FormatLogic.AddFormat(prodId, input.poids, input.litre, input.prix);
                return Redirect("/MaBoutique/Produit/GestionFormatProduit");
            }
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("formatId")>0)
            {
                formatId = HttpContext.Session.Get<int>("formatId");
                var result = await FormatLogic.GetFormatById(formatId);
                input = new Input
                {
                    litre = result.Litre,
                    poids = result.Poids,
                    prix = result.Prix
                };
            }
            return Page();
        }
    }
}
