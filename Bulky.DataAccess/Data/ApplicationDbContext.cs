
using BulkyBook.Models;

using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {


        // Passing Configuration to DbContext class by adding base reffering to DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                    
        }


        //DbSet is Crucial for making a table of Category Model 
        public DbSet<Category> Categories { get; set; }



        // by using modelBuilder we can seed data

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // Which entity we want to seed dtaa for : thats Category
            // We also use HasData to 
            modelbuilder.Entity<Category>().HasData(
                // We need new object of Category here and we populate Category entity fields here 
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                

                    );
        }
    }
}
