using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Functions
{
    public class LocalisationFunctions : ILocalisation
    {
        //CRUD Localisation
        //ADD new BoutiqueLocalisation
        public async Task<Localisation> AddBoutiqueLocalisation(int boutiqueId,string rue,string num,string ville, string codePostal,string pays)
        {

            Localisation newlocalisation = new Localisation
            {
                Btqid = boutiqueId,
                Rue = rue,
                Num = num,
                Ville= ville,
                Pays = pays,
                Codepostal=codePostal

            };
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                await context.Localisations.AddAsync(newlocalisation);
                await context.SaveChangesAsync();
            }

            return newlocalisation;
        }
        //ADD new PartenaireLocalisation
        public async Task<Localisation> AddPartenaireLocalisation(int id, string rue, string num, string ville, string codePostal, string pays)
        {

            Localisation newlocalisation = new Localisation
            {
                Id = id,
                Rue = rue,
                Num = num,
                Ville = ville,
                Pays = pays

            };
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                await context.Localisations.AddAsync(newlocalisation);
                await context.SaveChangesAsync();
            }

            return newlocalisation;
        }
        //ADD new PointRelaisLocalisation
        public async Task<Localisation> AddRelaisLocalisation(int boutiqueId, string rue, string num, string ville, string codePostal, string pays,string relaisNom)
        {

            Localisation newlocalisation = new Localisation
            {
                Btqid = boutiqueId,
                Rue = rue,
                Num = num,
                Ville = ville,
                Pays = pays,
                PrNom = relaisNom,
            };
            RelaisLocB relaisLocB = new RelaisLocB();
            newlocalisation.RelaisLocBs.Add(relaisLocB);

            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                await context.Localisations.AddAsync(newlocalisation);
                await context.SaveChangesAsync();
            }

            return newlocalisation;
        }
        //Update Localisation
        public async Task<Localisation> UpdateLocalisation(int localisationId, string rue, string num, string ville, string codePostal, string pays)
        {
            Localisation localisation = new Localisation();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                localisation = await context.Localisations.FirstOrDefaultAsync(l => l.Localisationid == localisationId);
                localisation.Rue = rue;
                localisation.Num = num;
                localisation.Ville = ville;
                localisation.Codepostal = codePostal;
                localisation.Pays = pays;
                context.Localisations.Update(localisation);
                await context.SaveChangesAsync();
            }
            return localisation;
        }
        //Supprimer Localisation
        public async Task<Boolean> DeleteLocalisation(int localisationId)
        {
            Localisation localisation = new Localisation();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                localisation = await context.Localisations.FirstOrDefaultAsync(p => p.Localisationid == localisationId);
                context.Localisations.Remove(localisation);
                await context.SaveChangesAsync();
            }
            return true;
        }
        //GET Mes Localisations de boutique
        public async Task<List<Localisation>> GetLocalisationsBoutique(int boutiqueId)
        {
            List<Localisation> localisations = new List<Localisation>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                localisations = await context.Localisations.Where(b => b.Btqid == boutiqueId).ToListAsync();
            }
            return localisations;
        }
        //GET Mes Localisations de Partenaire
        public async Task<List<Localisation>> GetLocalisationsPartenaire(int Id)
        {
            List<Localisation> localisations = new List<Localisation>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                localisations = await context.Localisations.Where(b => b.Id == Id).ToListAsync();
            }
            return localisations;
        }
    }
}

