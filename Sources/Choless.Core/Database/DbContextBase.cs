using System;
using System.Configuration;
using Choless.Core.Brands;
using Choless.Core.Tools;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace Choless.Core.Managers
{
    public abstract class DbContextBase : DbContext
    {
        string ConnectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (EnvironmentTool.IsReleassEnvironment)
                optionsBuilder.UseMySQL(ConnectionString);
            else if (EnvironmentTool.IsDevelopmentEnvironment)
            {
                var dbName = ConfigurationManager.AppSettings["DevelopmentDatabaseName"];
                if (string.IsNullOrEmpty(dbName))
                    throw new ArgumentNullException(
                        nameof(optionsBuilder),
                        "The Environment variable: DevelopmentDatabaseName is unset");
                optionsBuilder.UseMySQL(@"server=localhost;database=library;user=user;password=password;SslMode=None");
            }
            else
                optionsBuilder.UseInMemoryDatabase(ConnectionString);
        }

        protected DbContextBase(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
