using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class PartenaireFunctions : Ipartenaire
    {
        //CRUD Partenaire
        //ADD new Partenaire
        public async Task<Partenaire> AddPartenaire(string email,string password)
        {
            Partenaire newpartenaire = new Partenaire
            {
                Email = email,
                PasswordHash = password,
                EmailConfirmed=false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                
            };
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                await context.Partenaires.AddAsync(newpartenaire);
                await context.SaveChangesAsync();
            }
            return newpartenaire;
        }
    }
}
