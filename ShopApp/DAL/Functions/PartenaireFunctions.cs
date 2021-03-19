using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class PartenaireFunctions : Ipartenaire
    {
    //    static ARTSHOPContext context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions);
    //    //static UserManager<Partenaire> _userManager = new UserManager<Partenaire>(PartenaireStore, null, new PasswordHasher<Partenaire>(), null, null, null, null, null, null);
    //    //private UserManager<Partenaire> userManager = new UserManager<Partenaire,int>(new IUserStore<Partenaire, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(new ARTSHOPContext()));
    //    //private UserManager<Partenaire> userManager = new UserManager<Partenaire, int>(IUserStore<Partenaire,int>)
    //    //CRUD Partenaire
    //    //ADD new Partenaire
    //    public async Task<Partenaire> AddPartenaire(string email,string password)
    //    {
    //        Partenaire partenaire = await userManager.FindByEmailAsync(email);
    //        try
    //        {                
    //            if (partenaire==null)
    //            {
    //                partenaire = new Partenaire
    //                {
    //                    Email = email,
    //                    PasswordHash = password,
    //                    EmailConfirmed = false,
    //                    PhoneNumberConfirmed = false,
    //                    TwoFactorEnabled = false,
    //                    LockoutEnabled = false,
    //                    AccessFailedCount = 0,

    //                };
    //                using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
    //                {
    //                    IdentityResult result = await userManager.CreateAsync(partenaire);
    //                    //await context.Partenaires.AddAsync(partenaire);
    //                    //await context.SaveChangesAsync();
    //                }
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //        return partenaire;
    //    }
    }
}
