using BOL.BoutiqueLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    public class BoutiqueController : Controller
    {
        private BoutiqueLogic _boutique;

        public async Task<Boolean> AddBoutique(int partenaireid, int politiqueid,
    string descriptionC, string descriptionL, string raisonsociale, string siret,
    string siren, string tel, string codenaf, string codebanque, string codeguichet,
    string numcompte, string clerib, string domiciliation, string iban, string bic,
    string titulaire, string mail, string message, int ca, int nbsalarie, string siteweb,
    string statutjuridique, string btqseo)
        {
            bool result = await _boutique.AddBoutique(partenaireid, politiqueid, descriptionC, descriptionL, raisonsociale, siret,
                siren, tel, codenaf, codebanque, codeguichet,
                numcompte, clerib, domiciliation, iban, bic,
                titulaire, mail, message, ca, nbsalarie, siteweb,
                statutjuridique, btqseo);
            return result;

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
