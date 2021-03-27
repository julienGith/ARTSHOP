using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Extensions;


namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep1Model : PageModel
    {
        [BindProperty]
        public Step1 step1 { get; set; }
        public class Step1
        {
            [Required]
            [StringLength(500)]
            [Display(Name = "Description courte")]
            public string BDescriptionC { get; set; }
            [Required]
            [StringLength(4000)]
            [Display(Name = "Description Longue")]
            public string BDescriptionL { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Raison Sociale")]
            public string Raisonsociale { get; set; }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Set<Step1>("step1", step1);
                step1 = HttpContext.Session.Get<Step1>("step1");
                return RedirectToPage("/boutique/CreateBoutiqueStep2");
            }
            return Page();
            
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.Get<Step1>("step1")!=null)
            {
                step1 = HttpContext.Session.Get<Step1>("step1");
            }

            return Page();
        }
    }
}
