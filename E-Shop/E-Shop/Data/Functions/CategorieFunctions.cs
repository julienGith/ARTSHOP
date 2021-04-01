using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Functions
{
    public class CategorieFunctions : ICategorie
    {
        //CRUD
        //Créer une catégorie
        public async Task<Categorie> AddCategorie(string catNom, int? CatParentID)
        {
            if (CatParentID==null)
            {
                Categorie categorie = new Categorie
                {
                    Categorienom = catNom
                };
                using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
                {
                    context.Categories.Add(categorie);
                    context.SaveChanges();
                }
                return categorie;

            }
            else
            {
                Categorie categorie = new Categorie
                {
                    Categorienom = catNom
                };
                Categorie categorieParent = new Categorie();
                Catnav catnav = new Catnav();
                using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
                {
                    context.Categories.Add(categorie);
                    categorieParent = await context.Categories.FirstOrDefaultAsync(c => c.Categorieid == CatParentID);
                    catnav = await context.Catnavs.FirstAsync(c => c.CatCategorieid == categorieParent.Categorieid);
                    if (catnav==null)
                    {
                        catnav.CatCategorieid = categorieParent.Categorieid;
                        catnav.Categorieid = categorie.Categorieid;
                        context.Catnavs.Add(catnav);
                        context.SaveChanges();

                    }
                    else
                    {
                        catnav.Categorie.Categorieid = categorie.Categorieid;
                        context.Catnavs.Update(catnav);
                        context.SaveChanges();
                    }
                }
                return categorie;

            }
        }
        //Get all categories
        public async Task<List<Categorie>> GetAllCategories()
        {
            List<Categorie> categories = new List<Categorie>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                categories = await context.Categories.ToListAsync();
            }
            return categories;
        }

    }
}
