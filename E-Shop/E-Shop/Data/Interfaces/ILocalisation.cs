﻿using E_Shop.Entities;
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
        Task<Localisation> AddBoutiqueLocalisation(int boutiqueId, string rue, string num, string ville, string codePostal, string pays);

        //ADD new PartenaireLocalisation
        Task<Localisation> AddPartenaireLocalisation(int id, string rue, string num, string ville, string codePostal, string pays);

        //ADD new PointRelaisLocalisation
        Task<Localisation> AddRelaisLocalisation(int boutiqueId, string rue, string num, string ville, string codePostal, string pays, string relaisNom);

        //Update Localisation
        Task<Localisation> UpdateLocalisation(int localisationId, string rue, string num, string ville, string codePostal, string pays);

        //Supprimer Localisation
        Task<Boolean> DeleteLocalisation(int localisationd);

        //GET Mes Localisations de boutique
        Task<List<Localisation>> GetLocalisationsBoutique(int boutiqueId);

        //GET Mes Localisations de Partenaire
        Task<List<Localisation>> GetLocalisationsPartenaire(int Id);

    }
}