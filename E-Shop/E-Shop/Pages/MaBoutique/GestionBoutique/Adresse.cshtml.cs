using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.BoutiqueLogic;
using E_Shop.Logic.LocalisationLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.GestionBoutique
{
    public class AdresseModel : PageModel
    {
        private LocalisationLogic localisationLogic = new LocalisationLogic();
        public int boutiqueId { get; set; }
        Entities.Localisation localisation = new Entities.Localisation();
        [BindProperty]
        public Input input { get; set; }
        public class Input
        {
            [Required]
            [StringLength(255)]
            [Display(Name = "Rue")]
            public string Rue { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Numéro")]
            public string Num { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "ville")]
            public string Ville { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "CodePostal")]
            public string Codepostal { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Pays")]
            public string Pays { get; set; }
            [Required]
            public string Departement { get; set; }
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                localisation.Codepostal = input.Codepostal;
                localisation.Departement = input.Departement;
                localisation.Num = input.Num;
                localisation.Pays = input.Pays;
                localisation.Rue = input.Rue;
                localisation.Ville = input.Ville;
                await localisationLogic.UpdateLocalisation(localisation);
                return Redirect("/MaBoutique/GestionBoutique/GestionBoutique");
            }
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                boutiqueId = HttpContext.Session.Get<int>("btqId");
                localisation = await localisationLogic.GetLocalisationBoutique(boutiqueId);
                input = new Input
                {
                    Codepostal = localisation.Codepostal,
                    Departement = localisation.Departement,
                    Num = localisation.Num,
                    Pays = localisation.Pays,
                    Rue = localisation.Rue,
                    Ville = localisation.Ville
                };
            }
            return Page();
        }
    }
}
