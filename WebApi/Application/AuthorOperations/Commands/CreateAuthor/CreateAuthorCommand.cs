using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOpreations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        //Contex, mapper belki, dışardan author yaratmak için modele ihiyac var
        private readonly BookStoreDbContext _context;

        //Contex'i injectionla alabilmek için constroctur oluşturduk
        public CreateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname && x.BirthDate ==Model.BirthDate);
            if (author is not null)
                throw new InvalidOperationException("Yazar zaten mevcut");
            author = new Author();
            author.Name = Model.Name;
            author.Surname = Model.Surname;
            author.BirthDate = Model.BirthDate;
            //Author entitisine bu nesneyi ver
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }

}
