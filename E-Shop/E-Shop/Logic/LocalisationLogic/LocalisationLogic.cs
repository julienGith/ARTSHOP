﻿using E_Shop.Data.Functions;
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
        public async Task<Localisation> AddBoutiqueLocalisation(int boutiqueId, string rue, string num, string ville, string codePostal, string pays)
        {
            return await _localisation.AddBoutiqueLocalisation( boutiqueId, rue, num, ville, codePostal, pays);
        }
        //ADD new PartenaireLocalisation
        public async Task<Localisation> AddPartenaireLocalisation(int id, string rue, string num, string ville, string codePostal, string pays)
        {
            return await _localisation.AddPartenaireLocalisation(id, rue, num, ville, codePostal, pays);
        }
        //ADD new PointRelaisLocalisation
        public async Task<Localisation> AddRelaisLocalisation(int boutiqueId, string rue, string num, string ville, string codePostal, string pays, string relaisNom)
        {
            return await _localisation.AddRelaisLocalisation(boutiqueId, rue, num, ville, codePostal, pays, relaisNom);
        }
        //Update Localisation
        public async Task<Localisation> UpdateLocalisation(int localisationId, string rue, string num, string ville, string codePostal, string pays)
        {
            return await _localisation.UpdateLocalisation(localisationId, rue, num, ville, codePostal, pays);
        }
        //Supprimer Localisation
        public async Task<Boolean> DeleteLocalisation(int localisationId)
        {
            return await _localisation.DeleteLocalisation(localisationId);
        }
        //GET Mes Localisations de boutique
        public async Task<List<Localisation>> GetLocalisationsBoutique(int boutiqueId)
        {
            return await _localisation.GetLocalisationsBoutique(boutiqueId);
        }
        //GET Mes Localisations de Partenaire
        public async Task<List<Localisation>> GetLocalisationsPartenaire(int Id)
        {
            return await _localisation.GetLocalisationsPartenaire(Id);
        }
    }
}

