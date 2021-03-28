using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Functions
{
    public class PolitiqueFunctions : IPolitique
    {
        //CRUD Politque
        //ADD new Politique
        public async Task<Politique> AddPolitique(bool Echange, bool Remboursement, string Description)
        {

            Politique newpolitique = new Politique
            {
                Echange = Echange,
                Remboursement = Remboursement,
                Pltqdescription = Description

            };
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                await context.Politiques.AddAsync(newpolitique);
                await context.SaveChangesAsync();
            }

            return newpolitique;
        }
        //Update Politque
        public async Task<Boolean> UpdatePolitque(int politiqueid, bool Echange, bool Remboursement, string Description)
        {
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                Politique newpolitique = new Politique
                {
                    Politiqueid = politiqueid,
                    Echange = Echange,
                    Remboursement = Remboursement,
                    Pltqdescription = Description

                };

                context.Politiques.Update(newpolitique);
                await context.SaveChangesAsync();
            }

            return true;
        }
        //Supprimer Boutique
        public async Task<Boolean> DeletePolitque(int politiqueid)
        {
            Politique politique = new Politique();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                politique = await context.Politiques.FirstOrDefaultAsync(p => p.Politiqueid == politiqueid);
                context.Politiques.Remove(politique);
                await context.SaveChangesAsync();
            }
            return true;
        }
        //GET Ma Politique
        public async Task<Politique> GetBoutiqPolitique(int boutiqueId)
        {
            Politique politique = new Politique();
            int politiqueid = 0;
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                politiqueid = context.Boutiques.FirstOrDefault(b=>b.Btqid == boutiqueId).Politiqueid;
                politique = await context.Politiques.FirstOrDefaultAsync(p => p.Politiqueid == politiqueid);
            }
            return politique;
        }
    }
}
