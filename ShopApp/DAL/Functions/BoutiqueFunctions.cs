using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{

    public class BoutiqueFunctions
    {
        private readonly ARTSHOPContext _context;

        //ADD new Boutique
        public async Task<Boutique> Addboutique(int partenaireid, int politiqueid,string descriptionC,string descriptionL,string raisonsociale,string siret,string siren, string tel, string codenaf, string codebanque,string codeguichet, string numcompte, string clerib, string domiciliation, string iban, string bic, string titulaire, string mail, string message, int ca,int nbsalarie, string siteweb, string statutjuridique, string btqseo)
        {

            Boutique newboutique = new Boutique
            {
                BDescriptionC = descriptionC
            };

            await _context.Boutiques.AddAsync(newboutique);
            await _context.SaveChangesAsync();
            return newboutique;
        }
    }
}
