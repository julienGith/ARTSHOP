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
    public class ProduitFunctions : Iproduit
    {
        //CRUD Produit
        //Add New Produit
        public async Task<Produit> AddProduit(int Btqid, int Categorieid, int Livrtypid, decimal Prix, string Nom, string DescriptionC, string DescriptionL,
            short Stock, short Disponibilite, short Rabais, short Preparation, string Pseo, string PMetaKeywords, string PMetaTitre, bool Publier)
        {
            Produit newProduit = new Produit
            {
                Btqid = Btqid,
                Categorieid = Categorieid,
                Lvrtypid = Livrtypid,
                Prix = Prix,
                PNom = Nom,
                PDescriptionC = DescriptionC,
                PDescriptionL = DescriptionL,
                Stock = Stock,
                Disponibilite = Disponibilite,
                Rabais = Rabais,
                Preparation = Preparation,
                PSeo = Pseo,
                PMetaKeywords = PMetaKeywords,
                PMetaTitre = PMetaTitre,
                Publier = Publier
            };
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                await context.Produits.AddAsync(newProduit);
                await context.SaveChangesAsync();
            }

            return newProduit;
        }
        //Update Produit
        public async Task<Boolean> UpdateProduit(string Prodid, int Categorieid, int Livrtypid, decimal Prix, string Nom, string DescriptionC, string DescriptionL,
    short Stock, short Disponibilite, short Rabais, short Preparation, string Pseo, string PMetaKeywords, string PMetaTitre, bool Publier)
        {
            Produit produit = new Produit();
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                produit = await context.Produits.FirstOrDefaultAsync(p => p.Prodid == int.Parse(Prodid));
                produit.Categorieid = Categorieid;
                produit.Lvrtypid = Livrtypid;
                produit.Prix = Prix;
                produit.PNom = Nom;
                produit.PDescriptionC = DescriptionC;
                produit.PDescriptionL = DescriptionL;
                produit.Stock = Stock;
                produit.Disponibilite = Disponibilite;
                produit.Rabais = Rabais;
                produit.Preparation = Preparation;
                produit.PSeo = Pseo;
                produit.PMetaKeywords = PMetaKeywords;
                produit.PMetaTitre = PMetaTitre;
                produit.Publier = Publier;

                //context.Produits.Update(produit);
                await context.SaveChangesAsync();
            }

            return true;
        }

        //Recherche Produits
        //Get All Produits
        public async Task<List<Produit>> GetAllProduits()
        {
            List<Produit> produits = new List<Produit>();
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                produits = await context.Produits.Where(p => p.Publier == true).ToListAsync();

            }
            return produits;
        }

        //Par mot clé
        public async Task<List<Produit>> GetProduitsKW(string query)
        {
            List<Produit> produits = new List<Produit>();
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                produits = await context.Produits.Where(p => p.PMetaKeywords.ToLower().Contains(query.ToLower())).ToListAsync();

            }
            return produits;
        }

        //Par ID produit
        public async Task<Produit> GetProduitID(string query)
        {
            Produit produit = new Produit();
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                produit = await context.Produits.FirstOrDefaultAsync(p => p.Prodid == int.Parse(query));

            }
            return produit;
        }
    }
}
