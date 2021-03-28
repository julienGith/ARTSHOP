using E_Shop.Data.Interfaces;
using E_Shop.Data.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;

namespace E_Shop.Logic.PolitiqueLogic
{
    public class PolitiqueLogic
    {
        private IPolitique _politique = new PolitiqueFunctions();
        //CRUD Politque
        //ADD new Politique
        public async Task<Boolean> AddPolitique(bool Echange, bool Remboursement, string Description)
        {
            try
            {
                var result = await _politique.AddPolitique(Echange, Remboursement, Description);
                if (result.Politiqueid > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Update Politque
        public async Task<Boolean> UpdatePolitque(int politiqueid, bool Echange, bool Remboursement, string Description)
        {
            try
            {
                var result = await _politique.UpdatePolitque(politiqueid, Echange, Remboursement, Description);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Supprimer Boutique
        public async Task<Boolean> DeletePolitque(int politiqueid)
        {
            try
            {
                var result = await _politique.DeletePolitque(politiqueid);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //GET Ma Politique
        public async Task<Politique> GetBoutiqPolitique(int boutiqueId)
        {
            return await _politique.GetBoutiqPolitique(boutiqueId);
        }
    }
}
