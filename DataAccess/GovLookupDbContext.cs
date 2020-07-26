
using System.Collections.Generic;
using System.Data;


using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GovLookup.DataAccess
{
    public class GovLookupDbContext : DbContext
    {
       
      
       public IConfiguration Configuration { get; set; }
       


        public GovLookupDbContext()  : base()
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("GovLookupDbContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public IEnumerable<TCustomEntity> SqlQuery<TCustomEntity>(string query, IDictionary<string, object> parameters, CommandType commandType) where TCustomEntity : class
        {
            try
            {
                var sqlConnection = Database.GetDbConnection();
               
                var test = sqlConnection.Query<TCustomEntity>(query, parameters, commandTimeout: 240,
                    commandType: commandType);
                return test;
            }
            finally
            {
                // sqlConnection.Close();
            }
        }

     














    }
}
