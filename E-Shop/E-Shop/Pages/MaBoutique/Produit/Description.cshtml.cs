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
        public IActionResult OnPost()
        {
            HttpContext.Session.Set<Input>("Description", input);
            return RedirectToPage("/MaBoutique/Produit/Media");
        }
        public void OnGet()
        {
        }
    }
}
