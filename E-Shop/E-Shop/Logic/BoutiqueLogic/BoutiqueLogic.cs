using E_Shop.Data.Functions;
using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Logic.BoutiqueLogic
{
    public class BoutiqueLogic
    {
        private IBoutique _boutique = new BoutiqueFunctions();
        //CRUD Boutique
        //Add Boutique
        public async Task<Boutique> AddBoutique(int partenaireid, int politiqueid,
    string descriptionC, string descriptionL, string raisonsociale, string Nom, string siret,
    string siren, string tel, string codenaf, string codebanque, string codeguichet,
    string numcompte, string clerib, string domiciliation, string iban, string bic,
    string titulaire, string mail, string message, int ca, int nbsalarie, string siteweb,
    string statutjuridique, string btqseo, string dateCreation, string StripeAcct)
        {
            return await _boutique.AddBoutique(partenaireid, politiqueid, descriptionC, descriptionL, raisonsociale, Nom, siret,
            siren, tel, codenaf, codebanque, codeguichet,
            numcompte, clerib, domiciliation, iban, bic,
            titulaire, mail, message, ca, nbsalarie, siteweb,
            statutjuridique, btqseo, dateCreation, StripeAcct);
        }
        //Update Boutique
        public async Task<Boolean> UpdateBoutique(Boutique boutique)
        {
            var result = await _boutique.UpdateBoutique(boutique);

            return true;
        }

        //Get Mes boutiques
        public async Task<List<Boutique>> GetPartenaireBoutiques(int partenaireID)
        {
            return await _boutique.GetPartenaireBoutiques(partenaireID);
        }
        //GET All Boutiques
        public async Task<PaginatedList<Boutique>> GetAllBoutiques(int? pageIndex)
        {
            return await _boutique.GetAllBoutiques(pageIndex);
        }

        //Delete boutique
        public async Task<Boolean> DeleteBoutique(int btqid)
        {
            return await _boutique.DeleteBoutique(btqid);
        }
        //Get Boutique par Id boutique
        public async Task<Boutique> GetBoutiqueById(int boutiqueId)
        {
            return await _boutique.GetBoutiqueById(boutiqueId);
        }
        //Recherche partielle boutique par nom
        public async Task<List<Boutique>> GetBoutiquesByQuery(string query)
        {
            return await _boutique.GetBoutiquesByQuery(query);
        }
        //Get boutiques par catégorie id
        public async Task<PaginatedList<Boutique>> GetBoutiquesByCatId(int catId, int? pageIndex, string dept, Geo.Region region)
        {
            return await _boutique.GetBoutiquesByCatId(catId,pageIndex,dept,region);
        }
        //Get Boutique stripe acct
        public string GetBoutiqueStripeAcct(int btqId)
        {
            return _boutique.GetBoutiqueStripeAcct(btqId);
        }
        //Get Nombre de boutiques par régions et départements
        public async Task<Geo> GetBoutiqueCountByGeo(int catID) 
        {
            return await _boutique.GetBoutiqueCountByGeo(catID);
        }
    }
}
