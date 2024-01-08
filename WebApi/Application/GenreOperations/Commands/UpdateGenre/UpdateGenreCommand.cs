using System.Dynamic;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOpreations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        //update edilecek modele ihtiyaç var
        public UpdateGenreModel Model { get; set; }
        public readonly BookStoreDbContext _context;

        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Bu kategori bulunamadı");

            // genresin içinde hiç var mı, Any()= en az bir tane var mı
            if(_context.Genres.Any(x => x.Name.ToLower() ==Model.Name.ToLower() && x.Id != GenreId))  //aynı isimli farklı idli kontrolü
                throw new InvalidOperationException("Aynı isimli kategori zaten mevcut");
            //isActive update edilirken: kendi name'i ile kendini update edecek, yani name i nulllamadan yapacak
            //isnullorEmty ile name i nulllamadan yapacak
            genre.Name = string.IsNullOrEmpty( Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();

            

        }
        
    }

    public class UpdateGenreModel
    { //update edilecek alanları yaratıyoruz
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}