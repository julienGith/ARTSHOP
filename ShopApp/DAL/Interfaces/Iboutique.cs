using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Iboutique
    {
        //CRUD Boutique
        //ADD Boutique
        Task<Boutique> AddBoutique(int partenaireid, int politiqueid, string descriptionC,
            string descriptionL, string raisonsociale, string siret, string siren, string tel,
            string codenaf, string codebanque, string codeguichet, string numcompte, string clerib,
            string domiciliation, string iban, string bic, string titulaire, string mail,
            string message, int ca, int nbsalarie, string siteweb, string statutjuridique, string btqseo);
        

        //Recherche Boutique
        //Mes Boutiques
        Task<List<Boutique>> GetPartenaireBoutiques(string partenaireID);
        //GET All Boutiques
        Task<List<Boutique>> GetAllBoutiques();

    }
}
