using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.ProduitLogic
{
    public class ProduitLogic
    {
        private Iproduit _produit = new DAL.Functions.ProduitFunctions();
        //Add New Produit
        public async Task<Boolean> AddProduit(int Btqid, int Categorieid, int Livrtypid, decimal Prix, string Nom, string DescriptionC, string DescriptionL,
            short Stock, short Disponibilite, short Rabais, short Preparation, string Pseo, string PMetaKeywords, string PMetaTitre, bool Publier)
        {
            try
            {
                var result = await _produit.AddProduit( Btqid,  Categorieid,  Livrtypid,  Prix,  Nom,  DescriptionC,  DescriptionL,
             Stock,  Disponibilite,  Rabais,  Preparation,  Pseo,  PMetaKeywords,  PMetaTitre,  Publier);
                if (result.Prodid > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Get All Produits
        public async Task<List<Produit>> GetAllProduits()
        {
            List<Produit> produits = new List<Produit>();
            produits = await _produit.GetAllProduits();
            return produits;
        }
        //Recherche Produits
        public async Task<List<Produit>> GetProduits(string query)
        {
            List<Produit> produits = new List<Produit>();
            produits = await _produit.GetProduits(query);

            return produits;
        }
    }
}
