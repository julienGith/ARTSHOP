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
        public async Task<Localisation> AddBoutiqueLocalisation(int boutiqueId,string rue,string num,string ville, string codePostal,string pays, string departement)
        {

            Localisation newlocalisation = new Localisation
            {
                Btqid = boutiqueId,
                Rue = rue,
                Num = num,
                Ville= ville,
                Pays = pays,
                Codepostal=codePostal,
                Departement = departement

            };
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                await context.Localisations.AddAsync(newlocalisation);
                await context.SaveChangesAsync();
            }

            return newlocalisation;
        }
        //ADD new PartenaireLocalisation
        public async Task<Localisation> AddPartenaireLocalisation(int id, string rue, string num, string ville, string codePostal, string pays, string departement)
        {

            Localisation newlocalisation = new Localisation
            {
                Id = id,
                Rue = rue,
                Num = num,
                Ville = ville,
                Pays = pays,
                Departement = departement

            };
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                await context.Localisations.AddAsync(newlocalisation);
                await context.SaveChangesAsync();
            }

            return newlocalisation;
        }
        //ADD new PointRelaisLocalisation
        public async Task<Localisation> AddRelaisLocalisation(int boutiqueId, string rue, string num, string ville, string codePostal, string pays,string relaisNom, string departement)
        {
            Localisation newlocalisation = new Localisation
            {
                Btqid = boutiqueId,
                Rue = rue,
                Num = num,
                Ville = ville,
                Pays = pays,
                PrNom = relaisNom,
                Codepostal = codePostal,
                Departement = departement
            };
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                await context.Localisations.AddAsync(newlocalisation);
                await context.SaveChangesAsync();
                RelaisLocB relaisLocB = new RelaisLocB
                {
                    Localisationid = newlocalisation.Localisationid,
                    Btqid = boutiqueId
                };
                await context.RelaisLocBs.AddAsync(relaisLocB);
                await context.SaveChangesAsync();
            }
            return newlocalisation;
        }
        //Update Localisation
        public async Task<Localisation> UpdateLocalisation(Localisation localisation)
        {
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
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
        //Supprimer un point relais d'une boutique
        public async Task<Boolean> DeletePointRelaisBtq(int localisationId, int btqId)
        {
            RelaisLocB relaisLocB = new RelaisLocB();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                relaisLocB = await context.RelaisLocBs.FirstOrDefaultAsync(r => r.Localisationid == localisationId && r.Btqid == btqId);
                context.RelaisLocBs.Remove(relaisLocB);
                await context.SaveChangesAsync();
            }
            return true;
        }

        //GET Ma Localisation de boutique
        public async Task<Localisation> GetLocalisationBoutique(int boutiqueId)
        {
            Localisation localisation = new Localisation();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                localisation = await context.Localisations.FirstOrDefaultAsync(b => b.Btqid == boutiqueId);
            }
            return localisation;
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
        //Get Point Relais d'une Boutique
        public async Task<List<Localisation>> GetPointRelaisByBoutiqueId(int btqId)
        {
            List<Localisation> pointRelais = new List<Localisation>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                pointRelais = await context.RelaisLocBs.Include(p => p.Localisation).Where(r => r.Btqid == btqId).Select(l=>l.Localisation).ToListAsync();
            }
            return pointRelais;
        }
        //Get Localisation par Id 
        public async Task<Localisation> GetLocalisationById(int localisationId)
        {
            Localisation localisation = new Localisation();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                localisation = await context.Localisations.FirstOrDefaultAsync(l => l.Localisationid == localisationId);
            }
            return localisation;
        }
    }
}

