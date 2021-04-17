using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic.LocalisationLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.GestionPointRelais
{
    public class EditPointRelaisModel : PageModel
    {
        private LocalisationLogic LocalisationLogic = new LocalisationLogic();
        public Localisation localisation = new Localisation();
        public int localisationId { get; set; }
        public int btqId { get; set; }

        [BindProperty]
        public Input input { get; set; }
        public class Input
        {
            [StringLength(255)]
            [Display(Name = "Rue")]
            [Required]
            public string Rue { get; set; }
            [StringLength(255)]
            [Display(Name = "Numéro")]
            [Required]
            public string Num { get; set; }
            [StringLength(255)]
            [Display(Name = "ville")]
            [Required]
            public string Ville { get; set; }
            [StringLength(5, MinimumLength = 5)]
            [Display(Name = "CodePostal")]
            [Required]
            public string Codepostal { get; set; }
            [Display(Name = "Nom du point relais")]
            [StringLength(255)]
            [Required]
            public string PrNom { get; set; }
            public string Departement { get; set; }
            public string Pays { get; set; }
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.Get<int>("PrId") > 0)
                {
                    localisationId = HttpContext.Session.Get<int>("PrId");
                    localisation = await LocalisationLogic.GetLocalisationById(localisationId);
                    localisation.Codepostal = input.Codepostal;
                    localisation.Departement = input.Departement;
                    localisation.Num = input.Num;
                    localisation.Rue = input.Rue;
                    localisation.Ville = input.Ville;
                    localisation.PrNom = input.PrNom;
                    await LocalisationLogic.UpdateLocalisation(localisation);
                    return Redirect("/MaBoutique/GestionPointRelais/GestionPointRelais");
                }
                else
                {
                    if (HttpContext.Session.Get<int>("btqId") > 0)
                    {
                        btqId = HttpContext.Session.Get<int>("btqId");
                    }
                    await LocalisationLogic.AddRelaisLocalisation(btqId,input.Rue,input.Num,input.Ville,input.Codepostal,"France",input.PrNom,input.Departement);
                    return Redirect("/MaBoutique/GestionPointRelais/GestionPointRelais");
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("PrId") >0)
            {
                localisationId = HttpContext.Session.Get<int>("PrId");
                localisation = await LocalisationLogic.GetLocalisationById(localisationId);
                input = new Input
                {
                    Codepostal = localisation.Codepostal,
                    Departement = localisation.Departement,
                    Num = localisation.Num,
                    Pays = localisation.Pays,
                    PrNom = localisation.PrNom,
                    Rue = localisation.Rue,
                    Ville = localisation.Ville
                };
            }
            return Page();
        }
    }
}
