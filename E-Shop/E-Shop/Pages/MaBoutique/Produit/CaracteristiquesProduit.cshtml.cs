using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.ProduitLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class CaracteristiquesProduitModel : PageModel
    {
        private ProduitLogic ProduitLogic = new ProduitLogic();

        public Entities.Produit Produit = new Entities.Produit();

        [BindProperty]
        public Input input { get; set; }
        public class Input
        {
            [Required]
            [Display(Name = "Quantité disponible pour votre produit")]
            public short? Stock { get; set; }
            [Required]
            [Display(Name = "Nombre de jours nécessaires pour que le votre produit soit de nouveau disponible si le stock tombe à 0")]
            public short? Disponibilite { get; set; }
            [Required]
            [Display(Name = "Pourcentage de réduction du prix si vous souhaitez effectuer un rabais sur vorte produit")]
            public short? Rabais { get; set; }
            [Required]
            [Display(Name = "Nombre de jours nécessaire à la préparation de votre produit")]
            public short? Preparation { get; set; }
            [Required]
            [Display(Name = "Indiquez si vous souhaitez que votre produit soit visible sur le site")]
            public bool Publier { get; set; }

            public string PNom { get; set; }
            public string PDescriptionC { get; set; }
            public string PDescriptionL { get; set; }
            public int btqId { get; set; }
            public int catId { get; set; }
            public int prodId { get; set; }

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.Get<int>("prodIdUp") > 0)
                {
                    input.prodId = HttpContext.Session.Get<int>("prodIdUp");
                    Produit = await ProduitLogic.GetProduitById(input.prodId);
                    Produit.Preparation = input.Preparation;
                    Produit.Publier = input.Publier;
                    Produit.Rabais = input.Rabais;
                    Produit.Stock = input.Stock;
                    Produit.Disponibilite = input.Disponibilite;
                    await ProduitLogic.UpdateProduit(Produit);
                }
                else if (HttpContext.Session.Get<Input>("Description") != null)
                {
                    input.btqId = HttpContext.Session.Get<int>("btqId");
                    input.catId = HttpContext.Session.Get<int>("catEnfantId1");
                    var description = HttpContext.Session.Get<Input>("Description");
                    var result = await ProduitLogic.AddProduit(input.btqId, input.catId, description.PNom, description.PDescriptionC, description.PDescriptionL, input.Stock, input.Disponibilite,
                            input.Rabais, input.Preparation, input.Publier);
                    HttpContext.Session.Set<int>("prodId", result.Prodid);
                }
                return Redirect("/MaBoutique/Produit/GestionFormatProduit");
            }
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("prodIdUp") >0)
            {
                var prodId = HttpContext.Session.Get<int>("prodIdUp");
                var result = await ProduitLogic.GetProduitById(prodId);
                input = new Input
                {
                    Disponibilite = result.Disponibilite,
                    Preparation = result.Preparation,
                    Publier = result.Publier,
                    Rabais = result.Rabais,
                    Stock = result.Stock,
                    prodId = result.Prodid
                };
            }
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                if (HttpContext.Session.Get<int>("catEnfantId1") > 0)
                {
                    Input input = new Input
                    {
                        btqId = HttpContext.Session.Get<int>("btqId"),
                        catId = HttpContext.Session.Get<int>("catEnfantId1")
                    };
                }

            }

            return Page();
        }
    }
}
