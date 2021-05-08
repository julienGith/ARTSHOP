using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using E_Shop.Logic;
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
            string statutjuridique, string btqseo,string dateCreation)
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
                DateCreation = dateCreation
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
                mesboutiques = await context.Boutiques.Where(b => b.Id == UserID).ToListAsync();
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
                boutique = await context.Boutiques.FirstOrDefaultAsync(b => b.Btqid == boutiqueId);
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
        public async Task<PaginatedList<Boutique>> GetBoutiquesByCatId(int catId, int? pageIndex)
        {
            int pageSize = 3;
            List<Boutique> items=new List<Boutique>();
            PaginatedList<Boutique> boutiques;
            List<Catnav> CatnavEnfants1 = new List<Catnav>();
            List<Produit> produits = new List<Produit>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                CatnavEnfants1 = await context.Catnavs.Where(n => n.CatCategorieid == catId)
                     .Include(c => c.Categorie).ThenInclude(c => c.Produits)
                     .ThenInclude(p => p.Media).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                     .ThenInclude(p => p.Formats).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                     .ThenInclude(p => p.Avis).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                     .ThenInclude(p => p.Btq).ThenInclude(b => b.Media).ToListAsync();

                boutiques = await PaginatedList<Boutique>.CreateAsync(context.Boutiques.
                    Include(b=>b.Media).
                    Include(b => b.Avis).
                    Include(b=>b.Produits.Where(p=>p.Categorieid==catId)).
                    ThenInclude(p=>p.Media).Include(b => b.Produits).
                    ThenInclude(p=>p.Formats).AsNoTracking(), pageIndex ?? 1, pageSize);

                if (CatnavEnfants1.Count > 0)
                {
                    foreach (var item in CatnavEnfants1)
                    {
                        produits.AddRange(item.Categorie.Produits);
                    }
                    foreach (var b in boutiques)
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
            }
            return boutiques;
        }
    }
}
