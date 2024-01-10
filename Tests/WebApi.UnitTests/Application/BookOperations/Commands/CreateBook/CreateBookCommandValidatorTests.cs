
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.CreateBook;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>  //bu sayede mappper ve comtex'i kullanabiliyoruz burda
    {
        [Theory]   //inline data verebiliyoruz. 
        [InlineData("Lord of the Rings",0,1,1)]
        [InlineData("Lor",0,1,1)]
        [InlineData("",0,0,1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pagecount, int genreid,int authorId) //tester voiddir bir şey dönmez
        {
            CreateBookCommand cmd =new CreateBookCommand(null,null);
            cmd.Model =new CreateBookModel()
            {
                Title=title,
                PageCount=pagecount,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId=genreid,
                AuthorId=authorId
            };
            CreateBookCommandValidator vl = new CreateBookCommandValidator();
            var result = vl.Validate(cmd);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        
        [Fact]   // datetime bağımlılık yapıyor
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand cmd =new CreateBookCommand(null,null);
            cmd.Model =new CreateBookModel()
            {
                Title="Lord of the Rings",
                PageCount=100,
                PublishDate = DateTime.Now.Date,
                GenreId=1,
                AuthorId=1
            };
            CreateBookCommandValidator vl = new CreateBookCommandValidator();
            var result = vl.Validate(cmd);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]   // Happy 
        public void WhenValidInputsAreGiven_Validator_ShouldBeNotReturnError()
        {
            CreateBookCommand cmd =new CreateBookCommand(null,null);
            cmd.Model =new CreateBookModel()
            {
                Title="Lord of the Rings",
                PageCount=100,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId=1,
                AuthorId=1
            };
            CreateBookCommandValidator vl = new CreateBookCommandValidator();
            var result = vl.Validate(cmd);

            result.Errors.Count.Should().BeGreaterThanOrEqualTo(0);
        }

    }
}

