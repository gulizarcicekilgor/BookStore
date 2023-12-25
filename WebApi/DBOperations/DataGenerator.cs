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
                         Id = 1,
                         Title = "Lean s",
                         GenreId = 1,
                         PageCount = 232,
                         PublishDate = new DateTime(2022, 04, 10)
                     },
                    new Book
                    {
                        Id = 2,
                        Title = "dune",
                        GenreId = 2,
                        PageCount = 545,
                        PublishDate = new DateTime(2022, 03, 10)
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "asd",
                        GenreId = 3,
                        PageCount = 121,
                        PublishDate = new DateTime(2025, 03, 14)
                    }
                );
                context.SaveChanges();
            }
        }

    }

}