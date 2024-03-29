﻿using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Functions
{
    public class CategorieFunctions : ICategorie
    {
        public List<SelectListItem> Options { get; set; }
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
                    await context .SaveChangesAsync();
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
                    context.SaveChanges();
                    categorieParent = await context.Categories.FirstOrDefaultAsync(c => c.Categorieid == CatParentID);

                        catnav.CatCategorieid = categorieParent.Categorieid;
                        catnav.Categorieid = categorie.Categorieid;
                        context.Catnavs.Add(catnav);
                        await context.SaveChangesAsync();
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
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                categories = await context.Categories
                    .Include(c=>c.CatnavCatCategories).ThenInclude(c=>c.Categorie)
                    .ThenInclude(c => c.CatnavCatCategories).ThenInclude(c => c.Categorie)
                    .ThenInclude(c => c.CatnavCatCategories).ThenInclude(c => c.Categorie)
                    .ToListAsync();
            }
            return categories;
        }
        //Get All categories parents alimentaires
        public async Task<List<Categorie>> GetAllCategoriesParentsAlim()
        {
            List<Categorie> categories = new List<Categorie>();
            List<Catnav> Catnavs = new List<Catnav>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                Catnavs = await context.Catnavs.Include(c=>c.Categorie).Where(c=>c.CatCategorieid==3).ToListAsync();
                foreach (var item in Catnavs)
                {
                    categories.Add(item.Categorie);
                }
            }
            return categories;
        }
        //Get All categories enfants par id de catégorie parent
        public async Task<List<Categorie>> GetAllCategoriesEnfantsByParentId(int categorieParentId)
        {
            List<Categorie> categories = new List<Categorie>();
            List<Catnav> Catnavs = new List<Catnav>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                Catnavs = await context.Catnavs.Include(c => c.Categorie).Where(c => c.CatCategorieid == categorieParentId).ToListAsync();
                foreach (var item in Catnavs)
                {
                    categories.Add(item.Categorie);
                }
            }
            return categories;
        }
        //Get All categories parents par id de catégorie enfant
        public async Task<List<Categorie>> GetAllCategoriesParentsByEnfantId(int categorieEnfantId)
        {
            List<Categorie> categories = new List<Categorie>();
            List<Catnav> Catnavs = new List<Catnav>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                Catnavs = await context.Catnavs.Include(c => c.CatCategorie).Where(c => c.Categorieid == categorieEnfantId).ToListAsync();
                foreach (var item in Catnavs)
                {
                    categories.Add(item.Categorie);
                }
            }
            return categories;
        }
        //SelectList
        //Get Categories SelectListItem
        public List<SelectListItem> GetSelectListItemCategories()
        {
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                Options = context.Categories.Select(a =>new SelectListItem{Value = a.Categorieid.ToString(),Text = a.Categorienom}).ToList();
            }
            return Options;
        }
        //Get Categories parents SelectListItem
        public async Task<List<SelectListItem>> GetSelectListItemCategoriesParents()
        {
            List<Catnav> Catnavs = new List<Catnav>();
            List<Categorie> categories = new List<Categorie>();

            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                Catnavs = await context.Catnavs.Include(c => c.Categorie).Where(c => c.CatCategorieid == 3).ToListAsync();
                foreach (var item in Catnavs)
                {
                    categories.Add(item.Categorie);
                }
                Options = categories.Select(a => new SelectListItem { Value = a.Categorieid.ToString(), Text = a.Categorienom }).ToList();
            }
            return Options;
        }
        //Get Categories enfant SelectListItem
        public async Task<List<SelectListItem>> GetSelectListItemCategoriesEnfants(int categorieParentId)
        {
            List<Categorie> categories = new List<Categorie>();
            List<Catnav> Catnavs = new List<Catnav>();

            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                Catnavs = await context.Catnavs.Include(c => c.Categorie).Where(c => c.CatCategorieid == categorieParentId).ToListAsync();
                foreach (var item in Catnavs)
                {
                    categories.Add(item.Categorie);
                }
            }
            Options = categories.Select(a => new SelectListItem { Value = a.Categorieid.ToString(), Text = a.Categorienom }).ToList();

            return Options;
        }
        //Get catégories d'une boutique
        public async Task<List<Categorie>> GetCategoriesByBtqId(int btqId)
        {
            List<Categorie> categories = new List<Categorie>();
            List<Catnav> Catnavs1 = new List<Catnav>();
            List<Catnav> Catnavs2 = new List<Catnav>();

            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {

                //Catnavs1 = await context.Catnavs
                //    .Include(c => c.Categorie).ThenInclude(c=>c.CatnavCategories).ThenInclude(c=>c.Categorie)
                //    .Include(c => c.CatCategorie).Include(c => c.Categorie.Produits)
                //    .Where(c=>c.Categorie.Produits.Count()>0 && c.Categorie.Produits.Any(p=>p.Btqid==btqId)).ToListAsync();
                Catnavs1 = await context.Catnavs
                    .Include(c => c.Categorie).Include(c => c.CatCategorie).ThenInclude(c => c.CatnavCategories).ThenInclude(c=>c.CatCategorie)
                    .Include(c => c.Categorie.Produits)
                    .Where(c => c.Categorie.Produits.Any(p => p.Btqid == btqId)).ToListAsync();
                foreach (var item in Catnavs1)
                {
                    categories.Add(item.CatCategorie);
                    
                }
                categories=categories.Distinct().ToList();
            }
            return categories;
        }
        //Get catégorie par catégorie Id
        public async Task<Categorie> GetCategorieById(int catid)
        {
            Categorie categorie = new Categorie();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                categorie = await context.Categories.FirstOrDefaultAsync(c => c.Categorieid == catid);
            }
            return categorie;
        }
    }
}
