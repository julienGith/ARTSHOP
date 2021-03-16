using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.DataContext
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<ARTSHOPContext>
    {
        public ARTSHOPContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<ARTSHOPContext>();
            opsBuilder.UseSqlServer(appConfig.SqlConnectionString);
            return new ARTSHOPContext(opsBuilder.Options);
        }
    }
}
