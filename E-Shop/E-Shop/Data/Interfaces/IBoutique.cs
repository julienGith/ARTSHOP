using E_Shop.Entities;
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
            string descriptionL, string raisonsociale, string siret, string siren, string tel,
            string codenaf, string codebanque, string codeguichet, string numcompte, string clerib,
            string domiciliation, string iban, string bic, string titulaire, string mail,
            string message, int ca, int nbsalarie, string siteweb, string statutjuridique, string btqseo);
        //Update Boutique
        Task<Boolean> UpdateBoutique(int Btqid, int politiqueid,
            string descriptionC, string descriptionL, string raisonsociale, string siret,
            string siren, string tel, string codenaf, string codebanque, string codeguichet,
            string numcompte, string clerib, string domiciliation, string iban, string bic,
            string titulaire, string mail, string message, int ca, int nbsalarie, string siteweb,
            string statutjuridique, string btqseo);
        //Supprimer Boutique
        Task<Boolean> DeleteBoutique(string btqid);

        //Recherche Boutique
        //Mes Boutiques
        Task<List<Boutique>> GetPartenaireBoutiques(string partenaireID);
        //GET All Boutiques
        Task<List<Boutique>> GetAllBoutiques();
    }
}
