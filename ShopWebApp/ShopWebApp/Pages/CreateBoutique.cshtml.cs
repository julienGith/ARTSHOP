using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShopWebApp.Entities;
using ShopWebApp.Logic.BoutiqueLogic;

namespace ShopWebApp.Pages
{
    [Authorize]
    public class CreateBoutiqueModel : PageModel
    {
        private readonly UserManager<Partenaire> _userManager;
        private readonly ILogger<CreateBoutiqueModel> _logger;

        public CreateBoutiqueModel(UserManager<Partenaire> userManager, ILogger<CreateBoutiqueModel> logger)
        {
            _userManager = userManager;
            _logger = logger;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int Btqid { get; set; }
            public int Partenaireid { get; set; }
            public int Politiqueid { get; set; }

            [Required]
            [StringLength(100)]
            [Display(Name = "Description courte (100 caract�res)")]
            public string BDescriptionC { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Description Longue (255 caract�res)")]
            public string BDescriptionL { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Raison Sociale")]
            public string Raisonsociale { get; set; }
            [Required]
            [StringLength(14, ErrorMessage = "Le num�ro SIRET doit comporter 14 chiffres", MinimumLength = 14)]
            [Display(Name = "Siret")]
            public string Siret { get; set; }
            [Required]
            [StringLength(9, ErrorMessage = "Le num�ro SIREN doit comporter 9 chiffres", MinimumLength = 9)]
            [Display(Name = "Siren")]
            public string Siren { get; set; }
            [Required]
            [StringLength(15)]
            [Display(Name = "Tel")]
            public string Btqtel { get; set; }
            [Required]
            [StringLength(14, ErrorMessage = "Le code NAF doit comporter 14 chiffres", MinimumLength = 14)]
            [Display(Name = "Code NAF")]
            public string Codenaf { get; set; }
            [Required]
            [StringLength(5, ErrorMessage = "Le code Banque doit comporter 5 chiffres", MinimumLength = 5)]
            [Display(Name = "Code Banque")]
            public string Codebanque { get; set; }
            [Required]
            [StringLength(5, ErrorMessage = "Le code Guichet doit comporter 5 chiffres", MinimumLength = 5)]
            [Display(Name = "Code Guichet")]
            public string Codeguichet { get; set; }
            [Required]
            [StringLength(11, ErrorMessage = "Le Num�ro de Compte doit comporter 11 chiffres", MinimumLength = 11)]
            [Display(Name = "Num�ro de Compte")]
            public string Numcompte { get; set; }
            [Required]
            [StringLength(2, ErrorMessage = "La Cl� RIB doit comporter 2 chiffres", MinimumLength = 2)]
            [Display(Name = "Cl� RIB")]
            public string Clerib { get; set; }
            [Required]
            [StringLength(24, ErrorMessage = "La Domiciliation doit comporter 24 carat�res", MinimumLength = 24)]
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
            [Display(Name = "Mots Cl�")]
            public string Btqseo { get; set; }
        }
        
        //public async Task<IActionResult> OnGetAsync()
        //{
        //    if (user==null)
        //    {
        //        return Redirect("~/");
        //    }
        //    return Page();
        //}
        public async Task<IActionResult> OnPostAsync(BoutiqueLogic boutiqueLogic)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                //await boutiqueLogic.AddBoutique();
                return RedirectToPage();
            }
            else
            {
                return Page();
            }
        }
    }
}
