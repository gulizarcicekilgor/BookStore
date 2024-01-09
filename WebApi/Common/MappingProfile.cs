using AutoMapper;
using WebApi.Application.AuthorOpreations.Queries.AuthorDetail;
using WebApi.Application.AuthorOpreations.Queries.GetAuthors;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.Application.GenreOpreations.Queries;
using WebApi.Application.GenreOpreations.Queries.GenreDetail;
using WebApi.Application.GenreOpreations.Queries.GetGenres;

using WebApi.Entities;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();

            CreateMap<Book, BookDetailViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.Name}{src.Author.Surname}{src.Author.BirthDate}"));

            //createbookmodel objesi book objesine mapplensin
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                                            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.Name}{src.Author.Surname}{src.Author.BirthDate}"));
    
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<Author,AuthorsViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
        }
        
    }
}