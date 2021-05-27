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
    public class ProduitFunctions : IProduit
    {
        //CRUD Produit
        //Add New Produit
        public async Task<Produit> AddProduit(int boutiqueId, int categorieId, string nom, string descriptionC, string descriptionL,
            short? stock, short? disponibilite, short? rabais, short? preparation, bool publier)
        {
            Produit newproduit = new Produit();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                newproduit = new Produit
                {
                    Btqid = boutiqueId,
                    Categorieid = categorieId,
                    PNom = nom,
                    PDescriptionC = descriptionC,
                    PDescriptionL = descriptionL,
                    Stock = stock,
                    Disponibilite = disponibilite,
                    Rabais = rabais,
                    Preparation = preparation,
                    Publier = publier,
                };
                context.Produits.Add(newproduit);
                await context.SaveChangesAsync();
            }
            return newproduit;
        }

        //Modifier Produit
        public async Task<Produit> UpdateProduit(Produit produit)
        {
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.Produits.Update(produit);
                await context.SaveChangesAsync();
            }
            return produit;
        }
        //Delete Produit
        public async Task<Boolean> DeleteProduit(int prodId)
        {
            Produit produit = new Produit();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                produit = await context.Produits.FirstOrDefaultAsync(p => p.Prodid == prodId);
                context.Produits.Remove(produit);
                await context.SaveChangesAsync();
            }
            if (produit.Prodid > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Recherche Produit
        //Produits par boutique
        public async Task<List<Produit>> GetBoutiqueProduits(int btqId)
        {
            List<Produit> produits = new List<Produit>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                produits = await context.Produits.Include(m => m.Media).Include(f => f.Formats).Where(b => b.Btqid == btqId).ToListAsync();
            }
            return produits;
        }
        //Get produit par id produit
        public async Task<Produit> GetProduitById(int prodId)
        {
            Produit produit = new Produit();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                produit = await context.Produits.FirstOrDefaultAsync(p => p.Prodid == prodId);
            }
            return produit;
        }
        //Nom du produit par id produit
        public async Task<string> GetNomProduitById(int prodId)
        {
            Produit produit = new Produit();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                produit = await context.Produits.FirstOrDefaultAsync(p => p.Prodid == prodId);
            }
            return produit.PNom;
        }
        //Get produits par catégorie
        public async Task<PaginatedList<Produit>> GetProduitsByCatId(int catId, int? pageIndex, string sortOrder)
        {
            PaginatedList<Produit> produits;
            List<Catnav> CatnavEnfants1 = new List<Catnav>();
            List<Catnav> CatnavEnfants2 = new List<Catnav>();
            List<Catnav> CatnavEnfants = new List<Catnav>();
            Categorie categorieSubcatenf = new Categorie();
            int pageSize = 2;
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                IQueryable<Produit> prods = from p in context.Produits.Include(p => p.Avis)
                    .Include(p => p.Formats)
                    .Include(p => p.Media)
                    .Include(p => p.Btq).ThenInclude(b => b.Media)
                    .Include(p => p.Avis).Where(p=>p.Categorieid == catId).AsNoTracking()
                                            select p;

                CatnavEnfants1 = await context.Catnavs.Where(n => n.CatCategorieid == catId)
                    .Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Media).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Formats).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Avis).Include(c => c.Categorie).ThenInclude(c => c.Produits)
                    .ThenInclude(p => p.Btq).ThenInclude(b => b.Media).AsNoTracking().ToListAsync();
                if (CatnavEnfants1.Count > 0)
                {
                    foreach (var item in CatnavEnfants1)
                    {
                        foreach (var p in item.Categorie.Produits)
                        {
                            prods.Append<Produit>(p);
                        }
                    }
                }
                switch (sortOrder)
                {
                    case "price_asc":
                        prods = prods.OrderByDescending(p => p.Formats.Select(f => f.Prix).First()).Reverse();
                        break;
                    case "price_desc":
                        prods = prods.OrderByDescending(p => p.Formats.Select(f => f.Prix).First());
                        break;

                }

                produits = await PaginatedList<Produit>.CreateAsync(prods.AsNoTracking(), pageIndex ?? 1, pageSize);

                //produits = await PaginatedList<Produit>.CreateAsync(context.Produits.Include(p => p.Avis)
                //    .Include(p => p.Formats)
                //    .Include(p => p.Media)
                //    .Include(p => p.Btq).ThenInclude(b => b.Media)
                //    .Include(p => p.Avis)
                //    .Where(p => p.Categorieid == catId).AsNoTracking(), pageIndex ?? 1, pageSize);
                //if (CatnavEnfants1.Count > 0)
                //{
                //    foreach (var item in CatnavEnfants1)
                //    {
                //        foreach (var p in item.Categorie.Produits)
                //        {
                //            prods.Append<Produit>(p);

                //        }
                //        produits.AddRange(item.Categorie.Produits);
                //    }
                //}

            }

            return produits;
        }
        //Recherche partielle produits par nom
        public async Task<List<Produit>> GetListProduitByQuery(string query)
        {
            List<Produit> Produits = new List<Produit>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                Produits = await context.Produits.Include(p => p.Media).Where(p => p.PNom.Contains(query.ToLower())).AsNoTracking().Take(5).ToListAsync();
            }
            return Produits;
        }
    }
}
