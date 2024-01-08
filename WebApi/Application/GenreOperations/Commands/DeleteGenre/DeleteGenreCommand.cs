using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOpreations.DeleteGenre
{
    public class DeleteGenreCommad
    {
        private readonly BookStoreDbContext _context;
        public int GenreId { get; set; }


        //Contex'i injectionla alabilmek için constroctur oluşturduk
        public DeleteGenreCommad(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Bu kategori bulunamadı");

            //Genre entitisine bu nesneyi ver
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }

}
