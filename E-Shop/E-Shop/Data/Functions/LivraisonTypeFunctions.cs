using E_Shop.Data.Interfaces;
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
        public async Task<Livraisontype> AddLivraisonType(int btqId,string lvrDésignation,short lvrDelai, decimal lvrCout,decimal lvrCoutPsup)
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
        //Add livraisonType à un Produit
        public async Task<Livraisontype> AddLivraisonTypeProduit(int lvrTypeId, int prodId)
        {
            Livraisontype livraisontype = new Livraisontype();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                livraisontype = await context.Livraisontypes.FirstOrDefaultAsync(l => l.Lvrtypid == lvrTypeId);
                livraisontype.Prodid = prodId;
                await context.SaveChangesAsync();
            }
            return livraisontype;
        }
        //Update LivraisonType
        public async Task<Livraisontype> UpdateLivraisonType(int lvrTypeId,string lvrDésignation, short lvrDelai, decimal lvrCout, decimal lvrCoutPsup)
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

        //Recherche LivraisonType
        //Get LivraisonType par Boutique
        public async Task<List<Livraisontype>> GetLivraisonTypeByBoutique(int btqId)
        {
            List<Livraisontype> livraisontypes = new List<Livraisontype>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                livraisontypes = await context.Livraisontypes.Where(l => l.Btqid == btqId).ToListAsync();
            }
            return livraisontypes;
        }
        //Get LivraisonType by Id
        public async Task<Livraisontype> GetLivraisonTypeById(int lvrTypId)
        {
            Livraisontype livraisontype = new Livraisontype();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                livraisontype = await context.Livraisontypes.FirstOrDefaultAsync(l => l.Lvrtypid == lvrTypId);
            }
            return livraisontype;
        }
    }
}
