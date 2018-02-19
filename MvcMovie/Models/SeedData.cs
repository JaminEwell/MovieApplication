using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return; // DB has been seeded
                }
                context.Movie.AddRange(
                new Movie
                {
                    Title = "Hitch",
                    ReleaseDate = DateTime.Parse("2005-1-11"),
                    Genre = "Comedy",
                    Rating = "PG-13",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Avengers",
                    ReleaseDate = DateTime.Parse("2009-3-13"),
                    Genre = "Action",
                    Rating = "PG-13",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "X-Men",
                    ReleaseDate = DateTime.Parse("2010-2-13"),
                    Genre = "Action",
                    Rating = "PG-13",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "WaterWorld",
                    ReleaseDate = DateTime.Parse("2000-4-15"),
                    Genre = "Drama",
                    Rating = "R",
                    Price = 3.99M
                }
                );
                context.SaveChanges();
            }
        }
    }
}