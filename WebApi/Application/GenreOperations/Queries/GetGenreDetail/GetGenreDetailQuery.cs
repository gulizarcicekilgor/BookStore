using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOpreations.Queries.GenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        public readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadı");
            return _mapper.Map<GenreDetailViewModel>(genre);
        }
    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}



