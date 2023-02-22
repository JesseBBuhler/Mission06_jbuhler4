using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_jbuhler4.Models
{
    public class MovieDatabaseContext : DbContext
    {
        //Constructor
        public MovieDatabaseContext (DbContextOptions<MovieDatabaseContext> options) : base (options)
        {
            //Leave Blank for now
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName= "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS" }
                );

            mb.Entity<Movies>().HasData(
                new Movies
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "I like this movie."
                },
                new Movies
                {
                    MovieID = 2,
                    CategoryID = 2,
                    Title = "Everything Everywhere All at Once",
                    Year = 2022,
                    Director = "Daniel Kwan and Daniel Scheinert",
                    Rating = "R",
                    Edited = true,
                    LentTo = "",
                    Notes = ""
                },
                new Movies
                {
                    MovieID = 3,
                    CategoryID = 4,
                    Title = "Puss in Boots: The Last Wish",
                    Year = 2022,
                    Director = "Joel Crawford",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Sean",
                    Notes = "The animation is to die for"
                }
                );
        }
    }
}
