using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOpreations.Queries.GenreDetail;
using WebApi.Application.GenreOpreations.Queries.GetGenres;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {   // diğer containerden gelen 2 tane DI var.
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        //bunları injection ile alabilek için constructor
        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var obj =  query.Handle();
            return Ok(obj);
            
        }
        [HttpGet ("id")]
        public IActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_mapper, _context);
            query.GenreId = id;
            GetGenreDetailQueryValidator vl = new GetGenreDetailQueryValidator();
            vl.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }
        
        



    }
}