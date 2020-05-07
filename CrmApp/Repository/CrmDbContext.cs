using CrmApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmApp.Repository
{
    public class CrmDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
       public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }

        private readonly string connectionString =
            "Data Source=localhost;" +
            "Initial Catalog = SkgCrm; " +
            "Integrated Security = True;";

        //"Server =localhost; " +
        //"Database = SkgCrm; " +
        //"User Id = sa; " +
        //"Password = passw0rd;";

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }


    }
}
