using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                new Book
                {
                    Title = "Lean Startup",
                    GenreId = 1,
                    AuthorId =1,
                    PageCount = 232,
                    PublishDate = new DateTime(2022, 04, 10)
                },
                new Book
                {
                    Title = "Herland",
                    GenreId = 2,
                    AuthorId =3,
                    PageCount = 545,
                    PublishDate = new DateTime(2022, 03, 10)
                },
                new Book
                {
                    Title = "Dune",
                    GenreId = 2,
                    AuthorId =1,
                    PageCount = 121,
                    PublishDate = new DateTime(2025, 03, 14)
                }
            );
        }

    }

}