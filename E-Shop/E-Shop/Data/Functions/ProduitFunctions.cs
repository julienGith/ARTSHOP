﻿using E_Shop.Data.Interfaces;
using E_Shop.Entities;
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
        public async Task<Produit> AddProduit(int boutiqueId, int categorieId, decimal prix, string nom, string descriptionC,string descriptionL,
            short stock, short disponibilite,short rabais,short preparation,string seo,string metaKw,string metaTitre,bool publier)
        {
            Produit newproduit = new Produit();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                newproduit = new Produit
                {
                    Btqid = boutiqueId,
                    Categorieid = categorieId,
                    Prix = prix,
                    PNom = nom,
                    PDescriptionC = descriptionC,
                    PDescriptionL = descriptionL,
                    Stock = stock,
                    Disponibilite = disponibilite,
                    Rabais = rabais,
                    Preparation = preparation,
                    PSeo = seo,
                    PMetaKeywords = metaKw,
                    PMetaTitre = metaTitre,
                    Publier = publier
                };
                context.Produits.Add(newproduit);
                await context.SaveChangesAsync();
            }
            return newproduit;
        }

        //Modifier Produit
        public async Task<Produit> UpdateProduit(int prodId, int categorieId, decimal prix, string nom, string descriptionC, string descriptionL,
            short stock, short disponibilite, short rabais, short preparation, string seo, string metaKw, string metaTitre, bool publier)
        {
            Produit produit = new Produit();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                produit = await context.Produits.FirstOrDefaultAsync(p => p.Prodid == prodId);
                produit = new Produit
                {
                    Categorieid = categorieId,
                    Prix = prix,
                    PNom = nom,
                    PDescriptionC = descriptionC,
                    PDescriptionL = descriptionL,
                    Stock = stock,
                    Disponibilite = disponibilite,
                    Rabais = rabais,
                    Preparation = preparation,
                    PSeo = seo,
                    PMetaKeywords = metaKw,
                    PMetaTitre = metaTitre,
                    Publier = publier
                };
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
            if (produit.Prodid>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}