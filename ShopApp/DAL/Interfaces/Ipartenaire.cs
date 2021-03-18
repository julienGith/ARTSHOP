using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Ipartenaire
    {
        //CRUD Partenaire
        //Add new Partenaire
        Task<Partenaire> AddPartenaire(string email, string password);
    }
}
