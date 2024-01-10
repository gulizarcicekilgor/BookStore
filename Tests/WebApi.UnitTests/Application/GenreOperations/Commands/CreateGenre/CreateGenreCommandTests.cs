using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOpreations.CreateGenre;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>  //bu sayede mappper ve comtex'i kullanabiliyoruz burda
    {
        private readonly BookStoreDbContext _context;
        public CreateGenreModel Model { get; set; }

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]   //bunun bir test mesajı olduğunu fact den anlarız
        public void WhenAlreadyGenreExistTitleIsGiven_InvalidOperationException_ShouldBeReturn() //tester voiddir bir şey dönmez
        {
            //arrange ve assert 
            var genre = new Genre() { Name = "Test_ WhperationException_ShouldBeReturn"};
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = new CreateGenreModel() { Name = genre.Name };

            //Act
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu kategori zaten mevcut");

        }
           [Fact]   // Happy Path
          public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
          {   //arr
              CreateGenreCommand cmd = new CreateGenreCommand(_context);
              CreateGenreModel model = new CreateGenreModel()
              {
                  Name="Macera"
              };
              cmd.Model=model;

              FluentActions.Invoking(() => cmd.Handle()).Invoke();

              var genre = _context.Genres.SingleOrDefault(genre=>genre.Name==model.Name);

              genre.Should().NotBeNull();

              genre.Name.Should().Be(model.Name);
          }
          
    }
}