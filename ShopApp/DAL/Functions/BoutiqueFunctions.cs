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
        private readonly ARTSHOPContext _context;

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
                BDescriptionC = descriptionC
            };

            await _context.Boutiques.AddAsync(newboutique);
            await _context.SaveChangesAsync();
            return newboutique;
        }
        //GET partenaire's boutiques
        public async Task<List<Boutique>> GetPartenaireBoutiques(string partenaireID)
        {
            int id = int.Parse(partenaireID);
            List<Boutique> mesboutiques = new List<Boutique>();
            mesboutiques = await _context.Boutiques.Where(b => b.Partenaireid == id).ToListAsync();
            return mesboutiques;
        }
        //GET All Boutiques
        public async Task<List<Boutique>> GetAllBoutiques()
        {
            List<Boutique> allboutiques = new List<Boutique>();
            allboutiques = await _context.Boutiques.ToListAsync();
            return allboutiques;
        }
    }
}
