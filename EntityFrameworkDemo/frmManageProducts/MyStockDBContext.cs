using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmManageProducts
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
    public class MyStockDBContext : DbContext
    {
        public MyStockDBContext() { }

        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStockDB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //using Fluent API
            //to limit the length of a Category Name
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired() //NOT NULL
                .HasMaxLength(40);
            //Seed data into the Categories Table
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Beverages"},
                new Category { CategoryID = 2, CategoryName = "Condiments"},
                new Category { CategoryID = 3, CategoryName = "Confections"}
            );
        }
    }
}
