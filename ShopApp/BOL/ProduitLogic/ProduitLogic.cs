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
        //CRUD Produit
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
        //Update Produit
        public async Task<Boolean> UpdateProduit(string Prodid, int Categorieid, int Livrtypid, decimal Prix, string Nom, string DescriptionC, string DescriptionL,
    short Stock, short Disponibilite, short Rabais, short Preparation, string Pseo, string PMetaKeywords, string PMetaTitre, bool Publier)
        {
            var result = await _produit.UpdateProduit(Prodid, Categorieid, Livrtypid, Prix, Nom, DescriptionC, DescriptionL,
             Stock, Disponibilite, Rabais, Preparation, Pseo, PMetaKeywords, PMetaTitre, Publier);
            return result;
        }

        //Recherche Produits
        //Get All Produits
        public async Task<List<Produit>> GetAllProduits()
        {
            List<Produit> produits = new List<Produit>();
            produits = await _produit.GetAllProduits();
            return produits;
        }
        //Par mot clé
        public async Task<List<Produit>> GetProduitsKW(string query)
        {
            List<Produit> produits = new List<Produit>();
            produits = await _produit.GetProduitsKW(query);

            return produits;
        }
        //Par ID produit
        public async Task<Produit> GetProduitID(string query)
        {
            Produit produit = new Produit();
            produit = await _produit.GetProduitID(query);

            return produit;
        }
    }
}
