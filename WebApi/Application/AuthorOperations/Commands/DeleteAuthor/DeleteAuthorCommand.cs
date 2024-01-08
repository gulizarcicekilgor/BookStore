using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOpreations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public int AuthorId { get; set; }


        //Contex'i injectionla alabilmek için constroctur oluşturduk
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı");

            //Author entitisine bu nesneyi ver
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }

}
