﻿using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Functions
{
    public class LivraisonTypeFunctions : ILivraisonType
    {
        //CRUD LivraisonType
        //Création LivraisonType
        public async Task<Livraisontype> AddLivraisonType(int btqId,string lvrDésignation,short? lvrDelai, decimal? lvrCout,decimal? lvrCoutPsup)
        {
            Livraisontype livraisontype = new Livraisontype();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                livraisontype = new Livraisontype
                {
                    Btqid = btqId,
                    Lvrdesignation = lvrDésignation,
                    Lvrdelai = lvrDelai,
                    Lvrcout = lvrCout,
                    LvrcoutPsup = lvrCoutPsup
                };
                await context.Livraisontypes.AddAsync(livraisontype);
                await context.SaveChangesAsync();
            }
            return livraisontype;
        }
        //Update LivraisonType
        public async Task<Livraisontype> UpdateLivraisonType(int lvrTypeId,string lvrDésignation, short? lvrDelai, decimal? lvrCout, decimal? lvrCoutPsup)
        {
            Livraisontype livraisontype = new Livraisontype();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                livraisontype = await context.Livraisontypes.FirstOrDefaultAsync(l => l.Lvrtypid == lvrTypeId);
                livraisontype.Lvrdesignation = lvrDésignation;
                livraisontype.Lvrdelai = lvrDelai;
                livraisontype.Lvrcout = lvrCout;
                livraisontype.LvrcoutPsup = lvrCoutPsup;
                context.Livraisontypes.Update(livraisontype);
                await context.SaveChangesAsync();
            }
            return livraisontype;
        }
        //Delete LivraisonType
        public async Task<Boolean> DeleteLivraisonTypeById(int lvrTypId)
        {
            Livraisontype livraisontype = new Livraisontype();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                livraisontype = await context.Livraisontypes.FirstOrDefaultAsync(l => l.Lvrtypid == lvrTypId);
                context.Livraisontypes.Remove(livraisontype);
                await context.SaveChangesAsync();
            }
            return true;
        }
        //Add livraisonType à un Produit
        public async Task<ProdLvrType> AddLivraisonTypeProduit(int lvrTypeId, int prodId)
        {
            ProdLvrType prodLvrType = new ProdLvrType();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                prodLvrType = new ProdLvrType
                {
                    LvrTypeId = lvrTypeId,
                    ProdId = prodId
                };
                await context.ProdLvrTypes.AddAsync(prodLvrType);
                await context.SaveChangesAsync();
            }
            return prodLvrType;
        }
        //Remove livraisonType à un Produit
        public async Task<Boolean> RemoveLivraisonTypeProduit(int lvrTypeId)
        {
            ProdLvrType prodLvrType = new ProdLvrType();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                prodLvrType = await context.ProdLvrTypes.FirstOrDefaultAsync(l => l.LvrTypeId == lvrTypeId);
                context.ProdLvrTypes.Remove(prodLvrType);
                await context.SaveChangesAsync();
            }
            return true;
        }

        //Recherche LivraisonType
        //Get LivraisonType par Boutique
        public async Task<List<Livraisontype>> GetLivraisonTypeByBoutique(int btqId)
        {
            List<Livraisontype> livraisontypes = new List<Livraisontype>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                livraisontypes = await context.Livraisontypes.Where(l => l.Btqid == btqId).ToListAsync();
            }
            return livraisontypes;
        }
        //Get LivraisonType par userId
        public async Task<List<Livraisontype>> GetLivraisonTypeByUserId(int userId)
        {
            List<Livraisontype> livraisontypes = new List<Livraisontype>();
            Partenaire partenaire = new Partenaire();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                partenaire = await context.Partenaires.Include(p=>p.Boutiques).ThenInclude(b=>b.Livraisontypes).FirstOrDefaultAsync(p => p.Id == userId);
                livraisontypes =  partenaire.Boutiques.FirstOrDefault().Livraisontypes.ToList();
            }
            return livraisontypes;
        }
        //Get LivraisonType by Id
        public async Task<Livraisontype> GetLivraisonTypeById(int lvrTypId)
        {
            Livraisontype livraisontype = new Livraisontype();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                livraisontype = await context.Livraisontypes.FirstOrDefaultAsync(l => l.Lvrtypid == lvrTypId);
            }
            return livraisontype;
        }
        //Get LivraisonType by prodId
        public async Task<List<Livraisontype>> GetLivraisontypeByProdId(int prodId)
        {
            List<ProdLvrType> prodLvrTypes = new List<ProdLvrType>();
            Livraisontype livraisontype = new Livraisontype();
            List<Livraisontype> livraisontypes = new List<Livraisontype>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                prodLvrTypes = await context.ProdLvrTypes.Where(l => l.ProdId == prodId).ToListAsync();
                foreach (var item in prodLvrTypes)
                {
                    livraisontype = await context.Livraisontypes.FirstOrDefaultAsync(l => l.Lvrtypid == item.LvrTypeId);
                    livraisontypes.Add(livraisontype);
                }
            }
            return livraisontypes;
        }
    }
}
