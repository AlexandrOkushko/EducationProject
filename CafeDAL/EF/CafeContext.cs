using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDAL.EF
{
    public class CafeContext : DbContext
    {
        public CafeContext()
        {

        }

        public CafeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CafeDAL.Models.Dishes> Dishes { get; set; }
        public DbSet<CafeDAL.Models.DishIngredients> DishIngredients { get; set; }
        public DbSet<CafeDAL.Models.EmployeeMisconducts> EmployeeMisconducts { get; set; }
        public DbSet<CafeDAL.Models.Employees> Employees { get; set; }
        public DbSet<CafeDAL.Models.Gender> Gender { get; set; }
        public DbSet<CafeDAL.Models.Orders> Orders { get; set; }
        public DbSet<CafeDAL.Models.Products> Products { get; set; }
        public DbSet<CafeDAL.Models.OrderProducts> OrderProducts { get; set; }
        public DbSet<CafeDAL.Models.ReadyDishes> ReadyDish { get; set; }
        public DbSet<CafeDAL.Models.ReceiptProducts> ReceiptProducts { get; set; }
        public DbSet<CafeDAL.Models.Receipts> Receipts { get; set; }
        public DbSet<CafeDAL.Models.Roles> Roles { get; set; }
        public DbSet<CafeDAL.Models.Suppliers> Suppliers { get; set; }
        public DbSet<CafeDAL.Models.Warehouse> Warehouse { get; set; }

        /// <summary>
        /// Returns the name of the table to which the entity type is mapped or null if not mapped to a table.
        /// </summary>
        /// <param name="type">The entity type to get the table name for.</param>
        /// <returns>The name of the table to which the entity type is mapped.</returns>
        public string GetTableName(Type type) => Model.FindEntityType(type).GetTableName();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Rename when use asp.net
                // <add name="DB" connectionString="Server=(localdb)\MSSQLLocalDb; Integrated Security=true; AttachDbFileName=|DataDirectory|\StoreDb.mdf;" providerName="System.Data.SqlClient" />

                var connectionString = @"Server=(LocalDb)\MSSQLLocalDb;database=Cafe;Integrated Security=True; MultipleActiveResultSets=True;App=EntityFramework;";

                optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure()); // Включить повторную попытку подключения при ошибке
            }
        }

        // Fluent API
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //set the cascade options on the relationship
        //    //modelBuilder.Entity<Models.ProductsOrders>()
        //    //    .HasMany(e => e.Order)
        //    //    .WithMany(e => e.)
        //    //    .OnDelete(DeleteBehavior.ClientSetNull);
        //}
    }
}
