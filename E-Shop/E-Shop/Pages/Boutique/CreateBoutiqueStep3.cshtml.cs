using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Extensions;
using E_Shop.Logic.BoutiqueLogic;


namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep3Model : PageModel
    {
        
        [BindProperty]
        public Step3 step3 { get; set; }
        public class Step3
        {
            [Required]
            [StringLength(5, ErrorMessage = "Le code Banque doit comporter 5 chiffres", MinimumLength = 5)]
            [Display(Name = "Code Banque")]
            public string Codebanque { get; set; }
            [Required]
            [StringLength(5, ErrorMessage = "Le code Guichet doit comporter 5 chiffres", MinimumLength = 5)]
            [Display(Name = "Code Guichet")]
            public string Codeguichet { get; set; }
            [Required]
            [StringLength(11, ErrorMessage = "Le Numéro de Compte doit comporter 11 chiffres", MinimumLength = 11)]
            [Display(Name = "Numéro de Compte")]
            public string Numcompte { get; set; }
            [Required]
            [StringLength(2, ErrorMessage = "La Clé RIB doit comporter 2 chiffres", MinimumLength = 2)]
            [Display(Name = "Clé RIB")]
            public string Clerib { get; set; }
            [Required]
            //[StringLength(24, ErrorMessage = "La Domiciliation doit comporter 24 caratères", MinimumLength = 24)]
            [Display(Name = "Domiciliation")]
            public string Domiciliation { get; set; }
            [Required]
            [StringLength(27, ErrorMessage = "Le code IBAN doit comporter 27 chiffres", MinimumLength = 27)]
            [Display(Name = "IBAN")]
            public string Iban { get; set; }
            [Required]
            [StringLength(11, ErrorMessage = "Le code BIC doit comporter 11 chiffres", MinimumLength = 11)]
            [Display(Name = "BIC")]
            public string Bic { get; set; }
            [Required]
            [StringLength(140)]
            [Display(Name = "Titulaire")]
            public string Titulaire { get; set; }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Set<Step3>("step3", step3);

                return Redirect("/boutique/CreateBoutiqueStep4");
            }
            return Page();
        }
        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step3>("step3", step3);
            return Redirect("/boutique/CreateBoutiqueStep2");
        }
        public IActionResult OnGet()
        {

            if (HttpContext.Session.Get<Step3>("step3") != null)
            {
                step3 = HttpContext.Session.Get<Step3>("step3");
            }
            step3 = new Step3
            {
                Bic = "12121212121",
                Clerib = "2",
                Codebanque = "12345",
                Codeguichet = "12345",
                Domiciliation = "Banque du sud",
                Iban = "123123123123123123123123123",
                Numcompte = "12312312312",
                Titulaire = "Julien Boisserie"
            };
            return Page();
        }
   
    }
}
