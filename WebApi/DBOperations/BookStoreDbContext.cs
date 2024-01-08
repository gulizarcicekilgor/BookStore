using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }
        // resourceler hep çoğul olacak Books, Genres..
        public DbSet<Book> Books {get; set;}
        public DbSet<Genre>Genres{get; set;}
        public DbSet<Author>Authors{get; set;}

    }
}