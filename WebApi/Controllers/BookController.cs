using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]")]

    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
    
        public BookController (BookStoreDbContext context)
        {
            _context=context;
        }
        // private static List<Book> BookList = new List<Book>()
        // {
        //     new Book{
        //         Id = 1,
        //         Title="Lean s",
        //         GenreId=1,
        //         PageCount=232,
        //         PublishDate = new DateTime(2022,04,10)
        //     },
        //      new Book{
        //         Id = 2,
        //         Title="dune",
        //         GenreId=2,
        //         PageCount=545,
        //         PublishDate = new DateTime(2022,03,10)
        //     },
        //      new Book{
        //         Id = 3,
        //         Title="asd",
        //         GenreId=3,
        //         PageCount=121,
        //         PublishDate = new DateTime(2025,03,14)
        //     }
        // };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList =_context.Books.OrderBy(x =>x.Id).ToList<Book>();
            return bookList;
        }

       [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(book => book.Id == id).FirstOrDefault(); //singleordefult hata veriyor
            return book;
        }

/*
        [HttpGet]
        public Book Get([FromQuery] string id)
        {
            var book = _context.Books.Where(book => book.Id ==Convert.ToInt32(id)).SingleOrDefault();
            
            return book;
        }
*/
        
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);

            if(book is not null)   //listemde varsa bad reuest dön
                return BadRequest();
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
            

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book =_context.Books.SingleOrDefault(x=> x.Id == id);

            if(book is null)
                return BadRequest();

            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;

            _context.SaveChanges();  //artık db ile çalışıyoruz

            return Ok();

        }

        [HttpPatch("{id}")]
        public IActionResult UpdateBookTitle(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x=> x.Id == id);

            if(book is null)
                return BadRequest();
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            _context.SaveChanges();

            return Ok();

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault (x => x.Id == id);
            if(book is null)
                return BadRequest();
            
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }






        
    }

}