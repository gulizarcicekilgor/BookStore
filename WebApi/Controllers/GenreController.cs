using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOpreations.CreateGenre;
using WebApi.Application.GenreOpreations.DeleteGenre;
using WebApi.Application.GenreOpreations.Queries.GenreDetail;
using WebApi.Application.GenreOpreations.Queries.GetGenres;
using WebApi.Application.GenreOpreations.UpdateGenre;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {   // diğer containerden gelen 2 tane DI var.
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        //bunları injection ile alabilek için constructor
        public GenreController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);

        }
        [HttpGet("id")]
        public IActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_mapper, _context);
            query.GenreId = id;
            GetGenreDetailQueryValidator vl = new GetGenreDetailQueryValidator();
            vl.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenreModel)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = newGenreModel;

            CreateGenreCommandValidator vl = new CreateGenreCommandValidator();
            vl.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }


        [HttpPut("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel newGenreModel)
        {
            UpdateGenreCommand cmd = new UpdateGenreCommand(_context);
            cmd.GenreId = id;
            cmd.Model =newGenreModel;

            UpdateGenreCommandValidator vl = new UpdateGenreCommandValidator();
            vl.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand cmd = new DeleteGenreCommand(_context);
            cmd.GenreId = id;

            DeleteGenreCommandValidator vl = new DeleteGenreCommandValidator();
            vl.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }


    }
}