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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movies>().HasData(
                new Movies
                {
                    MovieID = 1,
                    category = "Action",
                    title = "Inception",
                    year = 2010,
                    director = "Christopher Nolan",
                    rating = "PG-13",
                    edited = false,
                    lentTo = "",
                    notes = "I like this movie."
                },
                new Movies
                {
                    MovieID = 2,
                    category = "Sci-fi",
                    title = "Everything Everywhere All at Once",
                    year = 2022,
                    director = "Daniel Kwan and Daniel Scheinert",
                    rating = "R",
                    edited = true,
                    lentTo = "",
                    notes = ""
                },
                new Movies
                {
                    MovieID = 3,
                    category = "Adventure",
                    title = "Puss in Boots: The Last Wish",
                    year = 2022,
                    director = "Joel Crawford",
                    rating = "PG",
                    edited = false,
                    lentTo = "Sean",
                    notes = "The animation is to die for"
                }
                );
        }
    }
}
