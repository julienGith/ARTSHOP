using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Interfaces
{
    public interface IFormat
    {
        //CRUD Format
        //Ajouter un Format
        Task<Format> AddFormat(int prodId, decimal? poids, decimal? litre, decimal? prix);
        //Modifier un Format
        Task<Format> UpdateFormat(Format format);
        //Supprimer un Format
        Task<Boolean> DeleteFormat(int formatId);

        //Recherche Format
        //Liste des formats d'un produit
        Task<List<Format>> GetFormatsByProductId(int prodId);
    }
}
