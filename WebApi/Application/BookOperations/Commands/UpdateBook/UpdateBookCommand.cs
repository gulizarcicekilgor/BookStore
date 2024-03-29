using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {    //consractor içinden set edilmek için
        private readonly IBookStoreDbContext _dbContext;

        //valide ederken hem modeli hem de book id valide eliyor.
        public int BookId {get; set;} // bookid ile update yapılıyor
        public UpdateBookModel Model {get; set;}

        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if(book is null)
                throw new InvalidCastException ("Güncellenecek kitap bulunamadı");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.AuthorId = Model.AuthorId != default ? Model.AuthorId : book.AuthorId;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _dbContext.SaveChanges();  //artık db ile çalışıyoruz

        }

        public class UpdateBookModel   //neler update edilecekse onlar modelde yer almalı
        {
            public string? Title { get; set; }
            public int GenreId { get; set; }
            public int AuthorId { get; set; }
        }
    }
}
