using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using E_Shop.Logic;
using E_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Functions
{
    public class BoutiqueFunctions : IBoutique
    {
        //CRUD Boutique
        //ADD new Boutique
        public async Task<Boutique> AddBoutique(int Id, int politiqueid,
            string descriptionC, string descriptionL, string raisonsociale, string Nom, string siret,
            string siren, string tel, string codenaf, string codebanque, string codeguichet,
            string numcompte, string clerib, string domiciliation, string iban, string bic,
            string titulaire, string mail, string message, int ca, int nbsalarie, string siteweb,
            string statutjuridique, string btqseo,string dateCreation, string StripeAcct)
        {

            Boutique newboutique = new Boutique
            {
                Id = Id,
                Politiqueid = politiqueid,
                BDescriptionC = descriptionC,
                BDescriptionL = descriptionL,
                Raisonsociale = raisonsociale,
                BtqNom = Nom,
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
                Btqseo = btqseo,
                DateCreation = dateCreation,
                StripeAcct = StripeAcct
            };
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                await context.Boutiques.AddAsync(newboutique);
                await context.SaveChangesAsync();
            }

            return newboutique;
        }
        //Update Boutique
        public async Task<Boolean> UpdateBoutique(Boutique boutique)
        {
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.Boutiques.Update(boutique);
                await context.SaveChangesAsync();
            }

            return true;
        }

        //Supprimer Boutique
        public async Task<Boolean> DeleteBoutique(int btqid)
        {
            Boutique boutique = new Boutique();
            List<Produit> btqproduits = new List<Produit>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                btqproduits = await context.Produits.Where(p => p.Btqid == btqid).ToListAsync();
                context.Produits.RemoveRange(btqproduits);
                boutique = await context.Boutiques.FirstOrDefaultAsync(b => b.Btqid == btqid);
                context.Boutiques.Remove(boutique);
                await context.SaveChangesAsync();
            }
            return true;
        }
        //GET Mes Boutiques
        public async Task<List<Boutique>> GetPartenaireBoutiques(int UserID)
        {
            List<Boutique> mesboutiques = new List<Boutique>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                mesboutiques = await context.Boutiques.Include(b => b.Media).Include(b => b.Localisations).Where(b => b.Id == UserID).ToListAsync();
            }
            return mesboutiques;
        }
        //Get Boutique par Id boutique
        public async Task<Boutique> GetBoutiqueById(int boutiqueId)
        {
            Boutique boutique = new Boutique();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                boutique = await context.Boutiques.Include(b => b.Media).Include(b => b.Localisations).FirstOrDefaultAsync(b => b.Btqid == boutiqueId);
            }
            return boutique;
        }
        //GET All Boutiques
        public async Task<PaginatedList<Boutique>> GetAllBoutiques(int? pageIndex)
        {
            PaginatedList<Boutique> allboutiques;
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                int pageSize = 3;
                allboutiques = await PaginatedList<Boutique>.CreateAsync(context.Boutiques.Include(b => b.Media).
                    Include(b => b.Avis).AsNoTracking(), pageIndex ?? 1, pageSize);
            }
            return allboutiques;
        }
        //Recherche partielle boutique par nom
        public async Task<List<Boutique>> GetBoutiquesByQuery(string query)
        {
            List<Boutique> boutiques = new List<Boutique>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                boutiques = await context.Boutiques.Include(b => b.Media).Where(b => b.BtqNom.Contains(query.ToLower())).ToListAsync();
            }
            return boutiques;
        }
        //Get boutiques par catégorie id
        public async Task<PaginatedList<Boutique>> GetBoutiquesByCatId(int catId, int? pageIndex, string dept, Geo.Region region)
        {
            int pageSize = 3;
            List<Boutique> btqs = new List<Boutique>();
            Boutique btq = new Boutique();
            List<int> btqId = new List<int>();
            PaginatedList<Boutique> boutiques;
            List<Catnav> CatnavEnfants1 = new List<Catnav>();
            List<Produit> produits = new List<Produit>();
            IQueryable<Boutique> bouts;
            List<Localisation> localisations = new List<Localisation>();
            Localisation localisation = new Localisation();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {

                CatnavEnfants1 = await context.Catnavs.Where(n => n.CatCategorieid == catId)
                     .Include(c => c.Categorie).ThenInclude(c => c.Produits)
                     .ThenInclude(p => p.Media).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                     .ThenInclude(p => p.Formats).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                     .ThenInclude(p => p.Avis).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                     .AsNoTracking().ToListAsync();
                bouts = from b in context.Boutiques.
                    Include(b => b.Media).
                    Include(b => b.Avis).Include(b => b.Localisations).
                    Include(b => b.Produits.Where(p => p.Categorieid == catId)).
                    ThenInclude(p => p.Media).Include(b => b.Produits).
                    ThenInclude(p => p.Formats).AsNoTracking()
                        select b;

                if (CatnavEnfants1.Count > 0)
                {
                    foreach (var item in CatnavEnfants1)
                    {
                        produits.AddRange(item.Categorie.Produits);
                    }
                    foreach (var b in bouts)
                    {
                        foreach (var p in produits)
                        {
                            if (p.Btqid==b.Btqid)
                            {
                                b.Produits.Add(p);
                            }
                        }
                    }
                }

                if (region!=null && dept==null)
                {
                    foreach (var depart in region.departements)
                    {
                        localisation = await context.Localisations.FirstOrDefaultAsync(l => l.Departement == depart.nom && l.PrNom == null && l.Btqid > 0);
                        if (localisation!=null)
                        {
                            localisations.Add(localisation);
                        }
                    }
                    foreach (var loca in localisations)
                    {
                        btq = await context.Boutiques.FirstOrDefaultAsync(b => b.Btqid == loca.Btqid);
                        if (btq!=null)
                        {
                            btqs.Add(btq);
                            btqId.Add(btq.Btqid);
                        }
                    }
                    bouts = bouts.Where(b => btqId.Contains(b.Btqid));
                }
                if (dept!=null)
                {
                    localisation = await context.Localisations.FirstOrDefaultAsync(l => l.Departement == dept && l.PrNom == null && l.Btqid > 0);
                    if (localisation!=null)
                    {
                        bouts = bouts.Where(b => b.Btqid == localisation.Btqid);
                    }
                    if (localisation==null)
                    {
                        bouts = from b in context.Boutiques.Include(b => b.Produits.Where(p => p.Categorieid == 0)).AsNoTracking()
                                select b;
                    }
                }
                boutiques = await PaginatedList<Boutique>.CreateAsync(bouts, pageIndex ?? 1, pageSize);
            }
            return boutiques;
        }
        //Get Boutique stripe acct
        public string GetBoutiqueStripeAcct(int btqId)
        {
            string StripeAcct;
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                StripeAcct = context.Boutiques.Where(b => b.Btqid == btqId).Select(b => b.StripeAcct).AsNoTracking().ToString();
            }
            return StripeAcct;
        }
        //Get Nombre de boutiques par régions et départements
        public async Task<Geo> GetBoutiqueCountByGeo()
        {
            Geo geo = new Geo();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                foreach (var region in geo.Regions)
                {
                    foreach (var dept in region.departements)
                    {
                        List<Localisation> localisations = await context.Localisations.Where(l=>l.Departement == dept.nom && l.PrNom == null && l.Btqid>0).ToListAsync();
                        dept.btqCount = localisations.Count;
                    }
                }
            }
            return geo;
        }
    }
}
