using E_Shop.Data.Functions;
using E_Shop.Data.Interfaces;
using E_Shop.Entities;
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
    string statutjuridique, string btqseo, string dateCreation)
        {
            return await _boutique.AddBoutique(partenaireid, politiqueid, descriptionC, descriptionL, raisonsociale, Nom, siret,
            siren, tel, codenaf, codebanque, codeguichet,
            numcompte, clerib, domiciliation, iban, bic,
            titulaire, mail, message, ca, nbsalarie, siteweb,
            statutjuridique, btqseo, dateCreation);
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
        public async Task<List<Boutique>> GetAllBoutiques()
        {
            return await _boutique.GetAllBoutiques();
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
        public async Task<List<Boutique>> GetBoutiquesByCatId(int catId)
        {
            return await _boutique.GetBoutiquesByCatId(catId);
        }
    }
}
