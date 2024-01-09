using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOpreations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x=>x.Id);
            List<AuthorsViewModel> returnObj = _mapper.Map<List<AuthorsViewModel>>(authors);
            return returnObj;
        }
    }
    public class AuthorsViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }

}

//prop


//is active true olanları getirmek için Where kullandık




//author için view model
