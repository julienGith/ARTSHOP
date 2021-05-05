using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Functions
{
    public class FormatFunctions : IFormat
    {
        //CRUD Format
        //Ajouter un Format
        public async Task<Format> AddFormat(int prodId,decimal? poids, decimal? litre, decimal? prix)
        {
            Format format = new Format();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                format = new Format
                {
                    Poids = poids,
                    Litre = litre,
                    Prix = prix,
                    Prodid = prodId
                };
                context.Formats.Add(format);
                await context.SaveChangesAsync();

            }
            return format;
        }
        //Modifier un Format
        public async Task<Format> UpdateFormat(Format format)
        {
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.Formats.Update(format);
                await context.SaveChangesAsync();
            }
            return format;
        }
        //Supprimer un Format
        public async Task<Boolean> DeleteFormat(int formatId)
        {
            Format format = new Format();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                format = await context.Formats.FirstOrDefaultAsync(f => f.Formatid == formatId);
                context.Formats.Remove(format);
                await context.SaveChangesAsync();
                if (format.Formatid > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //Recherche Format
        //Liste des formats d'un produit
        public async Task<List<Format>> GetFormatsByProductId(int prodId)
        {
            List<Format> formats = new List<Format>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                formats = await context.Formats.Where(f => f.Prodid == prodId).ToListAsync();
            }
            return formats;
        }
        //Format par id format
        public async Task<Format> GetFormatById(int formatId)
        {
            Format format = new Format();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                format = await context.Formats.FirstOrDefaultAsync(f => f.Formatid == formatId);
            }
            return format;
        }
    }
}
