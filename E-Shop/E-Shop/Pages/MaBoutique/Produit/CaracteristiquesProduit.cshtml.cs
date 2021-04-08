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
        public int btqId { get; set; }
        public int catId { get; set; }
        [BindProperty]
        public Input input { get; set; }
        public class Input
        {
            [Required]
            [Display(Name = "Indiquez la quantité disponible pour votre produit")]
            public short? Stock { get; set; }
            [Required]
            [Display(Name = "Indiquez le nombre de jours nécessaire pour que le votre produit soit de nouveau disponible si le stock tombe à 0")]
            public short? Disponibilite { get; set; }
            [Required]
            [Display(Name = "Indiquez un pourcentage de réduction du prix si vous souhaitez effectuer un rabais sur vorte produit")]
            public short? Rabais { get; set; }
            [Required]
            [Display(Name = "Indiquez le nombre de jours nécessaire à la préparation de votre produit")]
            public short? Preparation { get; set; }
            [Required]
            [Display(Name = "Indiquez le prix de votre produit")]
            public decimal? Prix { get; set; }
            [Required]
            [Display(Name = "Indiquez le Poids de votre produit")]
            public int? Poids { get; set; }
            [Required]
            [Display(Name = "Indiquez si vous souhaitez que votre produit soit visible sur le site")]
            public bool? Publier { get; set; }

            public string PNom { get; set; }
            public string PDescriptionC { get; set; }
            public string PDescriptionL { get; set; }

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.Get<Input>("Description") != null)
                {
                    var description = HttpContext.Session.Get<Input>("Description");
                    var result = await ProduitLogic.AddProduit(btqId, catId, input.Prix, description.PNom, description.PDescriptionC, description.PDescriptionL, input.Stock, input.Disponibilite,
                        input.Rabais, input.Preparation, input.Publier, input.Poids);
                    HttpContext.Session.Set<int>("prodId", result.Prodid);
                }
                return Redirect("/MaBoutique/Produit/ChoixTypeDeLivraison");
            }
            return Page();
        }
        public void OnGet()
        {
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                btqId = HttpContext.Session.Get<int>("btqId");
            }
            if (HttpContext.Session.Get<int>("Cat") > 0)
            {
                catId = HttpContext.Session.Get<int>("Cat");
            }
            else
            {
                if (HttpContext.Session.Get<int>("catEnfantId1") > 0)
                {
                    catId = HttpContext.Session.Get<int>("catEnfantId1");
                }
            }

        }
    }
}
