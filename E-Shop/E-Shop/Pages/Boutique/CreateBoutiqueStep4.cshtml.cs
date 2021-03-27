using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep4Model : PageModel
    {
        [BindProperty]
        public Step4 step4 { get; set; }
        public class Step4
        {
            [Required]
            [Display(Name = "Echange accepté")]
            public bool Echange { get; set; }
            [Required]
            [Display(Name = "Titulaire")]
            public bool Remboursement { get; set; }
            [Required]
            [Display(Name = "Description de votre politique")]
            public string Pltqdescription { get; set; }
        }
        public void OnGet()
        {
            if (HttpContext.Session.Get<Step4>("step4") != null)
            {
                step4 = HttpContext.Session.Get<Step4>("step4");
            }
        }
    }
}
