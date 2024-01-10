using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Components.Web;
using TestSetup;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>  //bu sayede mappper ve comtex'i kullanabiliyoruz burda
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {   _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]   //bunun bir test mesajı olduğunu fact den anlarız
        public void WhenAlreadyBookExistTitleIsGiven_InvalidOperationException_ShouldBeReturn() //tester voiddir bir şey dönmez
        {
            //arrange ve assert 
            var book = new Book() { Title = "Test_ WhenAlreadyBookExistTitleIsGiven_InvalidOperationException_ShouldBeReturn" , PageCount=100, PublishDate =new System.DateTime(1990,01,02),GenreId = 1, AuthorId=1};
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() {Title = book.Title};
            
            //Act
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");

        }
         [Fact]   // Happy Path
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {   //arr
            CreateBookCommand cmd = new CreateBookCommand(_context,_mapper);
            CreateBookModel model = new CreateBookModel()
            {
                Title="Hobbit",
                PageCount=100,
                PublishDate = DateTime.Now.Date.AddYears(-10),
                GenreId=1,
                AuthorId=1
            };
            cmd.Model=model;

            FluentActions.Invoking(() => cmd.Handle()).Invoke();

            var book = _context.Books.SingleOrDefault(book=>book.Title==model.Title);

            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.Title.Should().Be(model.Title);
            book.GenreId.Should().Be(model.GenreId);
            book.AuthorId.Should().Be(model.AuthorId);
        }



    }
}



