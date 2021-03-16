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
        private readonly ARTSHOPContext _context = new ARTSHOPContext();

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
            await _context.Produits.AddAsync(newProduit);
            await _context.SaveChangesAsync();
            return newProduit;
        }

        //Get All Produits
        public async Task<List<Produit>> GetAllProduits()
        {
            List<Produit> produits = new List<Produit>();
            produits = await _context.Produits.Where(p => p.Publier == true).ToListAsync();
            return produits;
        }
    }
}
