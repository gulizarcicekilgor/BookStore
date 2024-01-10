using System.Dynamic;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOpreations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        //update edilecek modele ihtiyaç var
        public UpdateAuthorModel Model { get; set; }
        public readonly IBookStoreDbContext _context;

        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı");

            // authorsin içinde hiç var mı, Any()= en az bir tane var mı
            if(_context.Authors.Any(x => x.Name.ToLower() ==Model.Name.ToLower() && x.Surname.ToLower() ==Model.Surname.ToLower() && x.Id != AuthorId))  //aynı isimli farklı idli kontrolü
                throw new InvalidOperationException("Aynı isimli yazar zaten mevcut");
            //isActive update edilirken: kendi name'i ile kendini update edecek, yani name i nulllamadan yapacak
            //isnullorEmty ile name i nulllamadan yapacak
            author.Name = string.IsNullOrEmpty( Model.Name.Trim()) ? author.Name : Model.Name;
            author.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) ? author.Surname : Model.Surname;
            _context.SaveChanges();

            

        }
        
    }

    public class UpdateAuthorModel
    { //update edilecek alanları yaratıyoruz
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}