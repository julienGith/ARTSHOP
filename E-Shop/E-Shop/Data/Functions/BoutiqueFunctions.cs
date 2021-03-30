﻿using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Functions
{
    public class BoutiqueFunctions : IBoutique
    {
        //CRUD Boutique
        //ADD new Boutique
        public async Task<Boutique> AddBoutique(int Id, int politiqueid,
            string descriptionC, string descriptionL, string raisonsociale, string Nom, string siret,
            string siren, string tel, string codenaf, string codebanque, string codeguichet,
            string numcompte, string clerib, string domiciliation, string iban, string bic,
            string titulaire, string mail, string message, int ca, int nbsalarie, string siteweb,
            string statutjuridique, string btqseo)
        {

            Boutique newboutique = new Boutique
            {
                Id = Id,
                Politiqueid = politiqueid,
                BDescriptionC = descriptionC,
                BDescriptionL = descriptionL,
                Raisonsociale = raisonsociale,
                BtqNom = Nom,
                Siret = siret,
                Siren = siren,
                Btqtel = tel,
                Codenaf = codenaf,
                Codebanque = codebanque,
                Codeguichet = codeguichet,
                Numcompte = numcompte,
                Clerib = clerib,
                Domiciliation = domiciliation,
                Iban = iban,
                Bic = bic,
                Titulaire = titulaire,
                Btqtmail = mail,
                Btqmessage = message,
                Ca = ca,
                Nbsalarie = nbsalarie,
                Siteweb = siteweb,
                Statutjuridique = statutjuridique,
                Btqseo = btqseo
            };
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                await context.Boutiques.AddAsync(newboutique);
                await context.SaveChangesAsync();
            }

            return newboutique;
        }
        //Update Boutique
        public async Task<Boolean> UpdateBoutique(int Btqid, int politiqueid,
    string descriptionC, string descriptionL, string raisonsociale, string Nom, string siret,
    string siren, string tel, string codenaf, string codebanque, string codeguichet,
    string numcompte, string clerib, string domiciliation, string iban, string bic,
    string titulaire, string mail, string message, int ca, int nbsalarie, string siteweb,
    string statutjuridique, string btqseo)
        {
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                Boutique boutique = new Boutique();
                boutique = await context.Boutiques.FirstOrDefaultAsync(b => b.Btqid == Btqid);
                boutique.Politiqueid = politiqueid;
                boutique.BDescriptionC = descriptionC;
                boutique.BDescriptionC = descriptionL;
                boutique.Raisonsociale = raisonsociale;
                boutique.BtqNom = Nom;
                boutique.Siret = siret;
                boutique.Siren = siren;
                boutique.Btqtel = tel;
                boutique.Codenaf = codenaf;
                boutique.Codebanque = codebanque;
                boutique.Codeguichet = codeguichet;
                boutique.Numcompte = numcompte;
                boutique.Clerib = clerib;
                boutique.Domiciliation = domiciliation;
                boutique.Iban = iban;
                boutique.Bic = bic;
                boutique.Titulaire = titulaire;
                boutique.Btqtmail = mail;
                boutique.Btqmessage = message;
                boutique.Ca = ca;
                boutique.Nbsalarie = nbsalarie;
                boutique.Siteweb = siteweb;
                boutique.Statutjuridique = statutjuridique;
                boutique.Btqseo = btqseo;

                context.Boutiques.Update(boutique);
                await context.SaveChangesAsync();
            }

            return true;
        }
        //Supprimer Boutique
        public async Task<Boolean> DeleteBoutique(int btqid)
        {
            Boutique boutique = new Boutique();
            List<Produit> btqproduits = new List<Produit>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                btqproduits = await context.Produits.Where(p => p.Btqid == btqid).ToListAsync();
                context.Produits.RemoveRange(btqproduits);
                boutique = await context.Boutiques.FirstOrDefaultAsync(b => b.Btqid == btqid);
                context.Boutiques.Remove(boutique);
                await context.SaveChangesAsync();
            }
            return true;
        }
        //GET Mes Boutiques
        public async Task<List<Boutique>> GetPartenaireBoutiques(string UserID)
        {
            int id = int.Parse(UserID);
            List<Boutique> mesboutiques = new List<Boutique>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                mesboutiques = await context.Boutiques.Where(b => b.Id == id).ToListAsync();
            }
            return mesboutiques;
        }
        //GET All Boutiques
        public async Task<List<Boutique>> GetAllBoutiques()
        {
            List<Boutique> allboutiques = new List<Boutique>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                allboutiques = await context.Boutiques.ToListAsync();
            }
            return allboutiques;
        }
    }
}
