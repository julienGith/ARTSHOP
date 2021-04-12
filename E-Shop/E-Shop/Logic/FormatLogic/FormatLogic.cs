using E_Shop.Data.Functions;
using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Logic.FormatLogic
{
    public class FormatLogic
    {
        private IFormat _Format = new FormatFunctions();
        //CRUD Format
        //Ajouter un Format
        public async Task<Format> AddFormat(int prodId, decimal? poids, decimal? litre, decimal? prix)
        {
            return await _Format.AddFormat(prodId,poids,litre,prix);
        }
        //Modifier un Format
        public async Task<Format> UpdateFormat(Format format)
        {
            return await _Format.UpdateFormat(format);
        }
        //Supprimer un Format
        public async Task<Boolean> DeleteFormat(int formatId)
        {
            return await _Format.DeleteFormat(formatId);
        }
        //Recherche Format
        //Liste des formats d'un produit
        public async Task<List<Format>> GetFormatsByProductId(int prodId)
        {
            return await _Format.GetFormatsByProductId(prodId);
        }
        //Format par id format
        public async Task<Format> GetFormatById(int formatId)
        {
            return await _Format.GetFormatById(formatId);
        }
    }
}
