using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Iproduit
    {
        Task<Produit> AddProduit(int Btqid, int Categorieid, int Livrtypid, decimal Prix, string Nom, string DescriptionC, string DescriptionL,
            short Stock, short Disponibilite, short Rabais, short Preparation, string Pseo, string PMetaKeywords, string PMetaTitre, bool Publier);

        Task<List<Produit>> GetAllProduits();
    }
}
