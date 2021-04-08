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
    public class InformationsBancairesModel : PageModel
    {
        private BoutiqueLogic boutiqueLogic = new BoutiqueLogic();
        public int boutiqueId { get; set; }
        Entities.Boutique boutique = new Entities.Boutique();
        [BindProperty]
        public Input input { get; set; }
        public class Input
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
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                boutique.Titulaire = input.Titulaire;
                boutique.Bic = input.Bic;
                boutique.Clerib = input.Clerib;
                boutique.Codeguichet = input.Codeguichet;
                boutique.Codebanque = input.Codebanque;
                boutique.Iban = input.Iban;
                boutique.Domiciliation = input.Domiciliation;
                boutique.Numcompte = input.Numcompte;
                await boutiqueLogic.UpdateBoutique(boutique);
                return Redirect("/MaBoutique/GestionBoutique/GestionBoutique");
            }
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                boutiqueId = HttpContext.Session.Get<int>("btqId");
                boutique = await boutiqueLogic.GetBoutiqueById(boutiqueId);
                input = new Input
                {
                    Bic = boutique.Bic,
                    Clerib = boutique.Clerib,
                    Codebanque = boutique.Codebanque,
                    Codeguichet = boutique.Codeguichet,
                    Domiciliation = boutique.Domiciliation,
                    Iban = boutique.Iban,
                    Numcompte = boutique.Numcompte,
                    Titulaire = boutique.Titulaire
                };
            }
            return Page();
        }
    }
}
