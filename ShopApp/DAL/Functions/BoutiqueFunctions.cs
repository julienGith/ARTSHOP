using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{

    public class BoutiqueFunctions : Iboutique
    {
        //CRUD Boutique
        //ADD new Boutique
        public async Task<Boutique> AddBoutique(int partenaireid, int politiqueid,
            string descriptionC,string descriptionL,string raisonsociale,string siret,
            string siren, string tel, string codenaf, string codebanque,string codeguichet,
            string numcompte, string clerib, string domiciliation, string iban, string bic,
            string titulaire, string mail, string message, int ca,int nbsalarie, string siteweb,
            string statutjuridique, string btqseo)
        {

            Boutique newboutique = new Boutique
            {
                Partenaireid = partenaireid,
                Politiqueid = politiqueid,
                BDescriptionC = descriptionC,
                BDescriptionL = descriptionL,
                Raisonsociale = raisonsociale,
                Siret = siret,
                Siren = siren,
                Btqtel = tel,
                Codenaf = codenaf,
                Codebanque = codebanque,
                Codeguichet = codeguichet,
                Numcompte = numcompte,
                Clerib = clerib,
                Domiciliation = domiciliation,
                Iban = iban,
                Bic = bic,
                Titulaire = titulaire,
                Btqtmail = mail,
                Btqmessage = message,
                Ca = ca,
                Nbsalarie = nbsalarie,
                Siteweb = siteweb,
                Statutjuridique = statutjuridique,
                Btqseo = btqseo
            };
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                await context.Boutiques.AddAsync(newboutique);
                await context.SaveChangesAsync();
            }

            return newboutique;
        }
        //GET Mes Boutiques
        public async Task<List<Boutique>> GetPartenaireBoutiques(string partenaireID)
        {
            int id = int.Parse(partenaireID);
            List<Boutique> mesboutiques = new List<Boutique>();
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                mesboutiques = await context.Boutiques.Where(b => b.Partenaireid == id).ToListAsync();
            }
            return mesboutiques;
        }
        //GET All Boutiques
        public async Task<List<Boutique>> GetAllBoutiques()
        {
            List<Boutique> allboutiques = new List<Boutique>();
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                allboutiques = await context.Boutiques.ToListAsync();
            }
            return allboutiques;
        }
    }
}
