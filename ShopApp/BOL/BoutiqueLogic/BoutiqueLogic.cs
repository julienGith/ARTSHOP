using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.BoutiqueLogic
{
   public class BoutiqueLogic
   {
        private Iboutique _boutique = new DAL.Functions.BoutiqueFunctions();
        
        //Add boutique
        public async Task<Boolean> AddBoutique(int partenaireid, int politiqueid,
    string descriptionC, string descriptionL, string raisonsociale, string siret,
    string siren, string tel, string codenaf, string codebanque, string codeguichet,
    string numcompte, string clerib, string domiciliation, string iban, string bic,
    string titulaire, string mail, string message, int ca, int nbsalarie, string siteweb,
    string statutjuridique, string btqseo)
        {
            try
            {            
                var result = await _boutique.AddBoutique(partenaireid, politiqueid, descriptionC, descriptionL, raisonsociale, siret,
                siren, tel, codenaf, codebanque, codeguichet,
                numcompte, clerib, domiciliation, iban, bic,
                titulaire, mail, message, ca, nbsalarie, siteweb,
                statutjuridique, btqseo);
                if (result.Btqid>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Get All boutiques
        public async Task<List<Boutique>> GetPartenaireBoutiques(string partenaireID)
        {
            List<Boutique> boutiques = await _boutique.GetAllBoutiques();
            return boutiques;
        }

   }
}
