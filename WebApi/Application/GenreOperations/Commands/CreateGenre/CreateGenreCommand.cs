using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOpreations.CreateGenre
{
    public class CreateGenreCommad
    {
        public CreaateGenreModel Model { get; set; }
        //Contex, mapper belki, dışardan genre yaratmak için modele ihiyac var
        private readonly BookStoreDbContext _context;

        //Contex'i injectionla alabilmek için constroctur oluşturduk
        public CreateGenreCommad(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre is not null)
                throw new InvalidOperationException("Bu kategori zaten mevcut");
            genre = new Genre();
            genre.Name = Model.Name;
            //Genre entitisine bu nesneyi ver
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreaateGenreModel
    {
        public string Name { get; set; }
    }

}
