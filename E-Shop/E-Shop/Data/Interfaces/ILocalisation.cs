using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Interfaces
{
    public interface ILocalisation
    {
        //CRUD Localisation
        //ADD new BoutiqueLocalisation
        Task<Localisation> AddBoutiqueLocalisation(int boutiqueId, string rue, string num, string ville, string codePostal, string pays, string departement);

        //ADD new PartenaireLocalisation
        Task<Localisation> AddPartenaireLocalisation(int id, string rue, string num, string ville, string codePostal, string pays, string departement);

        //ADD new PointRelaisLocalisation
        Task<Localisation> AddRelaisLocalisation(int boutiqueId, string rue, string num, string ville, string codePostal, string pays, string relaisNom, string departement);

        //Update Localisation
        Task<Localisation> UpdateLocalisation(Localisation localisation);

        //Supprimer Localisation
        Task<Boolean> DeleteLocalisation(int localisationd);

        //GET Ma Localisation de boutique
        Task<Localisation> GetLocalisationBoutique(int boutiqueId);

        //GET Mes Localisations de Partenaire
        Task<List<Localisation>> GetLocalisationsPartenaire(int Id);
        //Get Point Relais d'une Boutique
        Task<List<Localisation>> GetPointRelaisByBoutiqueId(int btqId);

    }
}
