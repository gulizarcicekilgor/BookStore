using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
                context.Genres.AddRange(
                    new Genre {Name = "Action"},
                    new Genre {Name = "Adventure"},
                    new Genre {Name = "Biography"},
                    new Genre {Name = "Comedy"},
                    new Genre {Name = "Crime"});
        }
    }

}