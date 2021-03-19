using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class PartenaireStore : IUserStore<Partenaire>
    {
        public void Dispose() { }
        //
        // Résumé :
        //     Creates the specified user in the user store.
        //
        // Paramètres :
        //   user:
        //     The user to create.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Retourne :
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the Microsoft.AspNetCore.Identity.IdentityResult of the creation operation.
        public async Task<IdentityResult> CreateAsync(Partenaire partenaire, CancellationToken cancellationToken) 
        {
                using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
                {
                    await context.Partenaires.AddAsync(partenaire);
                    await context.SaveChangesAsync();
                }
            if (partenaire.Partenaireid>0)
            {
               return IdentityResult.Success;
            }
            else
            {
                return IdentityResult.Failed(new IdentityError[] {new IdentityError{Code = "0001",Description = "user non créé"}});
            }
             
        }
        //
        // Résumé :
        //     Deletes the specified user from the user store.
        //
        // Paramètres :
        //   user:
        //     The user to delete.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Retourne :
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the Microsoft.AspNetCore.Identity.IdentityResult of the update operation.
        public async Task<IdentityResult> DeleteAsync(Partenaire partenaire, CancellationToken cancellationToken)
        {
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                context.Partenaires.Remove(partenaire);
                await context.SaveChangesAsync();
            }
            return IdentityResult.Success;
        }
        //
        // Résumé :
        //     Finds and returns a user, if any, who has the specified userId.
        //
        // Paramètres :
        //   userId:
        //     The user ID to search for.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Retourne :
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the user matching the specified userId if it exists.
        public async Task<Partenaire> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            Partenaire partenaire = new Partenaire();
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
               return partenaire = await context.Partenaires.FindAsync(userId);
            }
        }
        //
        // Résumé :
        //     Finds and returns a user, if any, who has the specified normalized user name.
        //
        // Paramètres :
        //   normalizedUserName:
        //     The normalized user name to search for.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Retourne :
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the user matching the specified normalizedUserName if it exists.
        public async Task<Partenaire> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            Partenaire partenaire = new Partenaire();
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                return partenaire = await context.Partenaires.FirstOrDefaultAsync(p=>p.NormalizedUserName==normalizedUserName);
            }
        }
        //
        // Résumé :
        //     Gets the normalized user name for the specified user.
        //
        // Paramètres :
        //   user:
        //     The user whose normalized name should be retrieved.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Retourne :
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the normalized user name for the specified user.
        public Task<string> GetNormalizedUserNameAsync(Partenaire partenaire, CancellationToken cancellationToken)
        {
            return Task.FromResult(string.Empty);
        }
        //
        // Résumé :
        //     Gets the user identifier for the specified user.
        //
        // Paramètres :
        //   user:
        //     The user whose identifier should be retrieved.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Retourne :
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the identifier for the specified user.
        public Task<string> GetUserIdAsync(Partenaire partenaire, CancellationToken cancellationToken) 
        {
            string userid =  partenaire.Partenaireid.ToString();
            return Task.FromResult(userid);
        }
        //
        // Résumé :
        //     Gets the user name for the specified user.
        //
        // Paramètres :
        //   user:
        //     The user whose name should be retrieved.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Retourne :
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the name for the specified user.
        public Task<string> GetUserNameAsync(Partenaire partenaire, CancellationToken cancellationToken)
        {
            string username = partenaire.UserName.ToString();
            return Task.FromResult(username);
        }
        //
        // Résumé :
        //     Sets the given normalized name for the specified user.
        //
        // Paramètres :
        //   user:
        //     The user whose name should be set.
        //
        //   normalizedName:
        //     The normalized name to set.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Retourne :
        //     The System.Threading.Tasks.Task that represents the asynchronous operation.
        public Task SetNormalizedUserNameAsync(Partenaire partenaire, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult(string.Empty);
        }
        //
        // Résumé :
        //     Sets the given userName for the specified user.
        //
        // Paramètres :
        //   user:
        //     The user whose name should be set.
        //
        //   userName:
        //     The user name to set.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Retourne :
        //     The System.Threading.Tasks.Task that represents the asynchronous operation.
        public Task SetUserNameAsync(Partenaire partenaire, string userName, CancellationToken cancellationToken) 
        {
            return Task.FromResult(string.Empty);
        }
        //
        // Résumé :
        //     Updates the specified user in the user store.
        //
        // Paramètres :
        //   user:
        //     The user to update.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken used to propagate notifications that the
        //     operation should be canceled.
        //
        // Retourne :
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the Microsoft.AspNetCore.Identity.IdentityResult of the update operation.
        public async Task<IdentityResult> UpdateAsync(Partenaire partenaire, CancellationToken cancellationToken)
        {
            using (var context = new ARTSHOPContext(ARTSHOPContext.ops.dbOptions))
            {
                context.Partenaires.Update(partenaire);
                await context.SaveChangesAsync();
            }
            return IdentityResult.Success;
        }
    }
}
