using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        { 
            context.Authors.AddRange(
                    new Author {Name = "John", Surname = "steinbeck ", BirthDate = new DateTime(1869, 04, 10)},
                    new Author {Name = "Yunus", Surname = "Emre ", BirthDate = new DateTime(1998, 04, 10)},
                    new Author {Name = "Ahmet", Surname = "Ümit ", BirthDate = new DateTime(1993, 04, 10)});
        }
    }
}