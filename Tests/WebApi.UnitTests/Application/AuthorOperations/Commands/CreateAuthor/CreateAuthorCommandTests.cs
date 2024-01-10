using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOpreations.CreateAuthor;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>  //bu sayede mappper ve comtex'i kullanabiliyoruz burda
    {
        private readonly BookStoreDbContext _context;
        public CreateAuthorModel Model { get; set; }

        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]   //bunun bir test mesajı olduğunu fact den anlarız
        public void WhenAlreadyAuthorExistTitleIsGiven_InvalidOperationException_ShouldBeReturn() //tester voiddir bir şey dönmez
        {
            //arrange ve assert 
            var author = new Author() { Name = "Test_ WhperationException_ShouldBeReturn", Surname = "Çiçekk", BirthDate = new System.DateTime(1990, 01, 02) };
            _context.Authors.Add(author);
            _context.SaveChanges();

            CreateAuthorCommand command = new CreateAuthorCommand(_context);
            command.Model = new CreateAuthorModel() { Name = author.Name };

            //Act
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar zaten mevcut");

        }
           [Fact]   // Happy Path
          public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
          {   //arr
              CreateAuthorCommand cmd = new CreateAuthorCommand(_context);
              CreateAuthorModel model = new CreateAuthorModel()
              {
                  Name="Hobbit",
                  Surname="namnmdms",
                  BirthDate = DateTime.Now.Date.AddYears(-50),
              };
              cmd.Model=model;

              FluentActions.Invoking(() => cmd.Handle()).Invoke();

              var author = _context.Authors.SingleOrDefault(author=>author.Name==model.Name);

              author.Should().NotBeNull();

              author.Name.Should().Be(model.Name);
              author.Surname.Should().Be(model.Surname);
              author.BirthDate.Should().Be(model.BirthDate);
          }
          
    }
}