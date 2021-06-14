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
            PaginatedList<Boutique> boutiques;
            List<Catnav> CatnavEnfants1 = new List<Catnav>();
            List<Catnav> CatnavEnfants2 = new List<Catnav>();
            Catnav catnv = new Catnav();
            List<Produit> produits = new List<Produit>();
            IQueryable<Boutique> bouts;
            List<Localisation> localisations = new List<Localisation>();
            Localisation localisation = new Localisation();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                CatnavEnfants1 = await context.Catnavs
                    .Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Media).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Formats).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Avis)
                    .Where(c => c.CatCategorieid == catId)
                    .AsNoTracking().ToListAsync();
                foreach (var catnav in CatnavEnfants1)
                {
                    CatnavEnfants2 = await context.Catnavs.Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Media).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Formats).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Avis)
                    .Where(c => c.CatCategorieid == catnav.Categorieid)
                    .AsNoTracking().ToListAsync();
                }
                if (CatnavEnfants1.Count > 0)
                {
                    foreach (var item in CatnavEnfants1)
                    {
                        produits.AddRange(item.Categorie.Produits);
                    }
                }
                if (CatnavEnfants2.Count>0)
                {
                    foreach (var item in CatnavEnfants2)
                    {
                        produits.AddRange(item.Categorie.Produits);
                    }
                }
                bouts = from b in context.Boutiques.
                    Include(b => b.Media).
                    Include(b => b.Avis).Include(b => b.Localisations).
                    Include(b => b.Produits.Where(p => p.Categorieid == catId || produits.Contains(p))).
                    ThenInclude(p => p.Media).Include(b => b.Produits).
                    ThenInclude(p => p.Formats).AsNoTracking()
                        select b;
                if (region != null && dept == null)
                {
                    localisations = await context.Localisations.Where(l => region.departements.Select(d => d.nom).Contains(l.Departement) && l.PrNom == null && l.Btqid > 0).ToListAsync();
                    bouts = await GetBouts(localisations, bouts,context);
                }
                if (dept != null)
                {
                    localisations = await context.Localisations.Where(l => l.Departement.ToUpper() == dept.ToUpper() && l.PrNom == null && l.Btqid > 0).ToListAsync();
                    bouts = await GetBouts(localisations, bouts, context);
                }
                boutiques = await PaginatedList<Boutique>.CreateAsync(bouts, pageIndex ?? 1, pageSize);
            }
            return boutiques;
        }

        private async Task<IQueryable<Boutique>> GetBouts(List<Localisation> localisations, IQueryable<Boutique> bouts, ApplicationDbContext context)
        {
            Boutique btq = new Boutique();
            List<int> btqId = new List<int>();
            if (localisations.Count > 0)
            {
                foreach (var loca in localisations)
                {
                    btq = await context.Boutiques.FirstOrDefaultAsync(b => b.Btqid == loca.Btqid);
                    if (btq != null)
                    {
                        btqId.Add(btq.Btqid);
                    }
                }
                bouts = bouts.Where(b => btqId.Contains(b.Btqid));
            }
            if (localisations.Count == 0)
            {
                bouts = from b in context.Boutiques.Include(b => b.Produits.Where(p => p.Categorieid == 0)).AsNoTracking()
                        select b;
            }
            return bouts;
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
        //Get Geo Nombre de boutiques par catégorie
        public async Task<Geo> GetBoutiqueCountByGeo(int catID)
        {
            Geo geo = new Geo();
            List<Localisation> localisations = new List<Localisation>();
            Boutique btq = new Boutique();
            List<Boutique> boutiques = new List<Boutique>();
            List<Catnav> CatnavEnfants1 = new List<Catnav>();
            List<Catnav> CatnavEnfants2 = new List<Catnav>();
            List<Produit> produits = new List<Produit>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                CatnavEnfants1 = await context.Catnavs.Where(n => n.CatCategorieid == catID)
                    .Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Media).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Formats).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Avis).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .AsNoTracking().ToListAsync();
                foreach (var catnav in CatnavEnfants1)
                {
                    CatnavEnfants2 = await context.Catnavs.Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Media).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Formats).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Avis)
                    .Where(c => c.CatCategorieid == catnav.Categorieid)
                    .AsNoTracking().ToListAsync();
                }
                if (CatnavEnfants1.Count > 0)
                {
                    foreach (var item in CatnavEnfants1)
                    {
                        produits.AddRange(item.Categorie.Produits);
                    }
                }
                if (CatnavEnfants2.Count > 0)
                {
                    foreach (var item in CatnavEnfants2)
                    {
                        produits.AddRange(item.Categorie.Produits);
                    }
                }

                foreach (var region in geo.Regions)
                {
                    foreach (var dept in region.departements)
                    {
                        localisations = await context.Localisations.Where(l=>l.Departement == dept.nom && l.PrNom == null && l.Btqid>0).ToListAsync();
                        boutiques = await context.Boutiques
                            .Include(b => b.Localisations)
                            .Include(b => b.Produits)
                            .Where(b => b.Localisations.Any(l => l.Departement.ToUpper() == dept.nom.ToUpper()) && ( b.Produits.Any(p=>p.Categorieid==catID) || b.Produits.Any(p=>produits.Contains(p))))
                            .AsNoTracking().ToListAsync();
                        dept.btqCount = boutiques.Count;
                    }
                }
            }
            return geo;
        }
    }
}
