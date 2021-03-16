﻿using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.BoutiqueLogic
{
   public class BoutiqueLogic
   {
        private Iboutique _boutique = new DAL.Functions.BoutiqueFunctions();
        //CRUD Boutique
        //Add Boutique
        public async Task<Boolean> AddBoutique(int partenaireid, int politiqueid,
    string descriptionC, string descriptionL, string raisonsociale, string siret,
    string siren, string tel, string codenaf, string codebanque, string codeguichet,
    string numcompte, string clerib, string domiciliation, string iban, string bic,
    string titulaire, string mail, string message, int ca, int nbsalarie, string siteweb,
    string statutjuridique, string btqseo)
        {
            try
            {            
                var result = await _boutique.AddBoutique(partenaireid, politiqueid, descriptionC, descriptionL, raisonsociale, siret,
                siren, tel, codenaf, codebanque, codeguichet,
                numcompte, clerib, domiciliation, iban, bic,
                titulaire, mail, message, ca, nbsalarie, siteweb,
                statutjuridique, btqseo);
                if (result.Btqid>0)
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
        //Update Boutique
        public async Task<Boolean> UpdateBoutique(int Btqid, int politiqueid,
    string descriptionC, string descriptionL, string raisonsociale, string siret,
    string siren, string tel, string codenaf, string codebanque, string codeguichet,
    string numcompte, string clerib, string domiciliation, string iban, string bic,
    string titulaire, string mail, string message, int ca, int nbsalarie, string siteweb,
    string statutjuridique, string btqseo)
        {
            var result = await _boutique.UpdateBoutique(Btqid, politiqueid,
     descriptionC, descriptionL, raisonsociale, siret,
     siren, tel, codenaf, codebanque, codeguichet,
     numcompte, clerib, domiciliation, iban, bic,
     titulaire, mail, message, ca, nbsalarie, siteweb,
     statutjuridique, btqseo);

            return true;
        }
        //Supprimer Boutique
        public async Task<Boolean> DeleteBoutique(string btqid)
        {
            var result = await _boutique.DeleteBoutique(btqid);

            return true;
        }

        //Recherche Boutiques
        //Get Mes Boutiques
        public async Task<List<Boutique>> GetPartenaireBoutiques(string partenaireID)
        {
            List<Boutique> boutiques = await _boutique.GetPartenaireBoutiques(partenaireID);
            return boutiques;
        }
        //GET All Boutiques
        public async Task<List<Boutique>> GetAllBoutiques()
        {
            List<Boutique> allboutiques = await _boutique.GetAllBoutiques();

            return allboutiques;
        }

    }
}
