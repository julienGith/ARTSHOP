using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.PartenaireLogic
{
    public class PartenaireLogic
    {
        private Ipartenaire _partenaire = new DAL.Functions.PartenaireFunctions();
        public async Task<Boolean> AddPartenaire(string email,string  password)
        {
            try
            {
                var result = await _partenaire.AddPartenaire(email, password);
                if (result.Partenaireid > 0)
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
    }
}
