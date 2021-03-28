using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Interfaces
{
    public interface IPolitique
    {
        //CRUD Politque
        //ADD new Politique
        Task<Politique> AddPolitique(bool Echange, bool Remboursement, string Description);

        //Update Politque
        Task<Boolean> UpdatePolitque(int politiqueid, bool Echange, bool Remboursement, string Description);

        //Supprimer Boutique
        Task<Boolean> DeletePolitque(int politiqueid);

        //GET Ma Politique
        Task<Politique> GetBoutiqPolitique(int boutiqueId);

    }
}
