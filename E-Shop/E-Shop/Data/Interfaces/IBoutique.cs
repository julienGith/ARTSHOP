using E_Shop.Entities;
using E_Shop.Logic;
using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Interfaces
{
    public interface IBoutique
    {
        //CRUD Boutique
        //ADD Boutique
        Task<Boutique> AddBoutique(int partenaireid, int politiqueid, string descriptionC,
            string descriptionL, string raisonsociale, string Nom, string siret, string siren, string tel,
            string codenaf, string codebanque, string codeguichet, string numcompte, string clerib,
            string domiciliation, string iban, string bic, string titulaire, string mail,
            string message, int ca, int nbsalarie, string siteweb, string statutjuridique, string btqseo, string dateCreation, string StripeAcct);
        //Update Boutique
        Task<Boolean> UpdateBoutique(Boutique boutique);
        //Supprimer Boutique
        Task<Boolean> DeleteBoutique(int btqid);

        //Recherche Boutique
        //Mes Boutiques
        Task<List<Boutique>> GetPartenaireBoutiques(int partenaireID);
        //GET All Boutiques
        Task<PaginatedList<Boutique>> GetAllBoutiques(int? pageIndex);
        //Get Boutique par Id boutique
        Task<Boutique> GetBoutiqueById(int boutiqueId);
        //Recherche partielle boutique par nom
        Task<List<Boutique>> GetBoutiquesByQuery(string query);
        //Get boutiques par catégorie id
        Task<PaginatedList<Boutique>> GetBoutiquesByCatId(int catId, int? pageIndex);
        //Get Boutique stripe acct
        string GetBoutiqueStripeAcct(int btqId);
        //Get Nombre de boutiques par régions et départements
        Geo GetBoutiqueCountByGeo();
    }
}
