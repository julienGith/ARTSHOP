using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep10Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep2Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep5Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep6Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep8Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep9Model;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep11Model : PageModel
    {
        public Step11 step11 { get; set; }
        public class Step11
        {
            public string lienImg1 { get; set; }
            public string lienImg2 { get; set; }
            public string lienVideo { get; set; }
            public string BtqDescription { get; set; }
            public string BtqNom { get; set; }
            public string Dept { get; set; }
            public string RaisonSociale { get; set; }
            public string Siret { get; set; }
            public string dateCreation { get; set; }


        }
        public void OnGet()
        {
            Step2 step2 = new Step2();
            Step5 step5 = new Step5();
            Step6 step6 = new Step6();
            Step8 step8 = new Step8();
            Step9 step9 = new Step9();
            Step10 step10 = new Step10();

            step2 = HttpContext.Session.Get<Step2>("step2");
            step5 = HttpContext.Session.Get<Step5>("step5");
            step6 = HttpContext.Session.Get<Step6>("step6");
            step8 = HttpContext.Session.Get<Step8>("step8");
            step9 = HttpContext.Session.Get<Step9>("step9");
            step10 = HttpContext.Session.Get<Step10>("step10");

            step11 = new Step11
            {
                BtqDescription = step5.BDescriptionL,
                BtqNom = step2.Nom,
                lienImg1 = step8.Lien,
                lienImg2 = step9.Lien,
                lienVideo = step10.Lien,
                Dept = step6.Departement,
                RaisonSociale = step2.Raisonsociale,
                Siret = step2.Siret,
                dateCreation = step5.dateCreation
            };
        }
    }
}
