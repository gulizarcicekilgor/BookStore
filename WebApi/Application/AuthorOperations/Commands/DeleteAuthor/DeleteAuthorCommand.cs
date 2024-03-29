using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOpreations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _context;
        public int AuthorId { get; set; }


        //Contex'i injectionla alabilmek için constroctur oluşturduk
        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            var author_book=_context.Books.SingleOrDefault(x=>x.AuthorId == AuthorId);
            if (author_book is not null)
                throw new InvalidOperationException("yazar kitabı yayında. Önce kitabı silmelisiniz");
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı");

            //Author entitisine bu nesneyi ver
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }

}
