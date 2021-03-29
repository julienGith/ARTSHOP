using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Interfaces
{
    public interface IMedia
    {
        //CRUD Médias
        //Add Boutique Médias
        Task<Medium> AddBoutiqueMedias(int boutiqueId, string lien, bool image, bool video, string description);
    }
}
