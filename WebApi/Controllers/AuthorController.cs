using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOpreations.CreateAuthor;
using WebApi.Application.AuthorOpreations.DeleteAuthor;
using WebApi.Application.AuthorOpreations.Queries.AuthorDetail;
using WebApi.Application.AuthorOpreations.Queries.GetAuthors;
using WebApi.Application.AuthorOpreations.UpdateAuthor;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {   // diğer containerden gelen 2 tane DI var.
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        //bunları injection ile alabilek için constructor
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);

        }
        [HttpGet("id")]
        public IActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_mapper, _context);
            query.AuthorId = id;
            GetAuthorDetailQueryValidator vl = new GetAuthorDetailQueryValidator();
            vl.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthorModel)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context);
            command.Model = newAuthorModel;

            CreateAuthorCommandValidator vl = new CreateAuthorCommandValidator();
            vl.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }


        [HttpPut("id")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel newAuthorModel)
        {
            UpdateAuthorCommand cmd = new UpdateAuthorCommand(_context);
            cmd.AuthorId = id;
            cmd.Model =newAuthorModel;

            UpdateAuthorCommandValidator vl = new UpdateAuthorCommandValidator();
            vl.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand cmd = new DeleteAuthorCommand(_context);
            cmd.AuthorId = id;

            DeleteAuthorCommandValidator vl = new DeleteAuthorCommandValidator();
            vl.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }


    }
}