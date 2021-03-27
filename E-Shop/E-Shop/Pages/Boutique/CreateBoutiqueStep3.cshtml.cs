using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Extensions;
using E_Shop.Logic.BoutiqueLogic;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep1Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep2Model;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep3Model : PageModel
    {
        private BoutiqueLogic boutiqueLogic = new BoutiqueLogic();
        
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
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Set<Step3>("step3", step3);
                //CreateBoutiqueStep1Model.Step1 step1 = new CreateBoutiqueStep1Model.Step1();
                //CreateBoutiqueStep2Model.Step2 step2 = new CreateBoutiqueStep2Model.Step2();
                //step1 = HttpContext.Session.Get<Step1>("step1");
                //step2 = HttpContext.Session.Get<Step2>("step2");
                //await boutiqueLogic.AddBoutique(step1.UserId, 0, step1.BDescriptionC, step1.BDescriptionL, step1.Raisonsociale, step2.Siret, step2.Siren, step2.Btqtel,
                //    step2.Codenaf, step3.Codebanque, step3.Codeguichet, step3.Numcompte, step3.Clerib, step3.Domiciliation, step3.Iban, step3.Bic, step3.Titulaire, step2.Btqtmail,
                //    null, step2.Ca, step2.Nbsalarie, step2.Siteweb, step2.Statutjuridique, step2.Btqseo);
                return Redirect("/boutique/CreateBoutiqueStep4");
            }
            return Page();
        }
        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step3>("step3", step3);
            return Redirect("/boutique/CreateBoutiqueStep2");
        }
        public void OnGet()
        {
            if (HttpContext.Session.Get<Step3>("step3") != null)
            {
                step3 = HttpContext.Session.Get<Step3>("step3");
            }
        }
    }
}
