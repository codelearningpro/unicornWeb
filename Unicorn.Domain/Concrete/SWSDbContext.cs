using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Unicorn.Domain.Interfaces;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Unicorn.Domain.Entities;


namespace Unicorn.Domain.Concrete
{
    public class SWSDbContext : DbContext
    {
       #region Public Properties   
        public int UserID { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerSignIn> CustomerSignIn { get; set; }
        public string ConnectionString { get; set; }
        #endregion
        
        public SWSDbContext()
        {
            Database.SetInitializer<SWSDbContext>(null);


            ConnectionString = "Data Source=unicorndb.cdwywkyzaxqh.us-east-1.rds.amazonaws.com;Initial Catalog=unicornDB;Persist Security Info=True;User ID=raj;Password=Kalai123!";
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerSignIn>().ToTable("Customer");
            modelBuilder.Entity<CustomerSignIn>().ToTable("CustomerSignIn");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }

    }
}
