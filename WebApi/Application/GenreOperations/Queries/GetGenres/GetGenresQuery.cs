using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOpreations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x=>x.IsActive).OrderBy(x=>x.Id);
            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }
    }
    public class GenresViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }

}

//prop


//is active true olanları getirmek için Where kullandık




//genre için view model
