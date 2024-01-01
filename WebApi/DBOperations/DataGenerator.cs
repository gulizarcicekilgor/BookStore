using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                     new Book
                     {
                         Title = "Lean Startup",
                         GenreId = 1,
                         PageCount = 232,
                         PublishDate = new DateTime(2022, 04, 10)
                     },
                    new Book
                    {
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 545,
                        PublishDate = new DateTime(2022, 03, 10)
                    },
                    new Book
                    {
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 121,
                        PublishDate = new DateTime(2025, 03, 14)
                    }
                );
                context.SaveChanges();
            }
        }

    }

}