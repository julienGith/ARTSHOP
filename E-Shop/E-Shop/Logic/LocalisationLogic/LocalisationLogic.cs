using E_Shop.Data.Functions;
using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Logic.LocalisationLogic
{
    public class LocalisationLogic
    {
        private ILocalisation _localisation = new LocalisationFunctions();
        //CRUD Localisation
        //ADD new BoutiqueLocalisation
        public async Task<Localisation> AddBoutiqueLocalisation(int boutiqueId, string rue, string num, string ville, string codePostal, string pays, string departement)
        {
            return await _localisation.AddBoutiqueLocalisation( boutiqueId, rue, num, ville, codePostal, pays, departement);
        }
        //ADD new PartenaireLocalisation
        public async Task<Localisation> AddPartenaireLocalisation(int id, string rue, string num, string ville, string codePostal, string pays, string departement)
        {
            return await _localisation.AddPartenaireLocalisation(id, rue, num, ville, codePostal, pays,departement);
        }
        //ADD new PointRelaisLocalisation
        public async Task<Localisation> AddRelaisLocalisation(int boutiqueId, string rue, string num, string ville, string codePostal, string pays, string relaisNom, string departement)
        {
            return await _localisation.AddRelaisLocalisation(boutiqueId, rue, num, ville, codePostal, pays, relaisNom,departement);
        }
        //Update Localisation
        public async Task<Localisation> UpdateLocalisation(Localisation localisation)
        {
            return await _localisation.UpdateLocalisation(localisation);
        }
        //Supprimer Localisation
        public async Task<Boolean> DeleteLocalisation(int localisationId)
        {
            return await _localisation.DeleteLocalisation(localisationId);
        }
        //Supprimer un point relais d'une boutique
        public async Task<Boolean> DeletePointRelaisBtq(int localisationId, int btqId)
        {
            return await _localisation.DeletePointRelaisBtq(localisationId, btqId);
        }
        //GET Ma Localisation de boutique
        public async Task<Localisation> GetLocalisationBoutique(int boutiqueId)
        {
            return await _localisation.GetLocalisationBoutique(boutiqueId);
        }
        //GET Mes Localisations de Partenaire
        public async Task<List<Localisation>> GetLocalisationsPartenaire(int Id)
        {
            return await _localisation.GetLocalisationsPartenaire(Id);
        }
        //Get Point Relais d'une Boutique
        public async Task<List<Localisation>> GetPointRelaisByBoutiqueId(int btqId)
        {
            return await _localisation.GetPointRelaisByBoutiqueId(btqId);
        }
        //Get Localisation par Id 
        public async Task<Localisation> GetLocalisationById(int localisationId)
        {
            return await _localisation.GetLocalisationById(localisationId);
        }
    }
}

