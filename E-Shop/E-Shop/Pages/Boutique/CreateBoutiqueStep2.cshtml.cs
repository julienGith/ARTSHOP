using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Extensions;
using E_Shop.Logic;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep2Model : PageModel
    {
        [BindProperty]
        public Step2 step2 { get; set; }
        public class Step2
        {
            [Required]
            [StringLength(14, ErrorMessage = "Le numéro SIRET doit comporter 14 chiffres", MinimumLength = 14)]
            [Display(Name = "Siret")]
            public string Siret { get; set; }
            [Required]
            [StringLength(9, ErrorMessage = "Le numéro SIREN doit comporter 9 chiffres", MinimumLength = 9)]
            [Display(Name = "Siren")]
            public string Siren { get; set; }
            [Required]
            [StringLength(14, ErrorMessage = "Le code NAF doit comporter 14 chiffres", MinimumLength = 14)]
            [Display(Name = "Code NAF")]
            public string Codenaf { get; set; }
            [Required]
            [StringLength(15)]
            [Display(Name = "Tel")]
            public string Btqtel { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Btqtmail { get; set; }
            public string Btqmessage { get; set; }
            public int? Ca { get; set; }
            public int? Nbsalarie { get; set; }
            public string Siteweb { get; set; }
            public string Statutjuridique { get; set; }
            [Required]
            [StringLength(100)]
            [Display(Name = "Mots Clé")]
            public string Btqseo { get; set; }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!Luhn.CheckLuhn(step2.Siren))
                {
                    ModelState.AddModelError("Siren", "Le numéro Siren est incorrect");
                    return Page();
                }
                if (!Luhn.CheckLuhn(step2.Siret))
                {
                    ModelState.AddModelError("Siret", "Le numéro Siret est incorrect");
                    return Page();
                }

                HttpContext.Session.Set<Step2>("step1", step2);
                return Redirect("/boutique/CreateBoutiqueStep3");
            }
            return Page();
        }
        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step2>("step2", step2);
            return Redirect("/boutique/CreateBoutiqueStep1");
        }
        public void OnGet()
        {
            if (HttpContext.Session.Get<Step2>("step2") != null)
            {
                step2 = HttpContext.Session.Get<Step2>("step2");
            }
        }
    }
}
