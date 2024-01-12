using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;
using WebApi.UserOpreations.Commands.CreateToken;
using WebApi.UserOpreations.Commands.CreateUser;
using WebApi.UserOpreations.Commands.RefreshToken;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    { 
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;  // appsettings altındaki verilere ulaşmamı sağlıyor

      
        public UserController(IBookStoreDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUserModel)
        {
            CreateUserCommand command = new CreateUserCommand(_context,_mapper);
            command.Model = newUserModel;
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult <Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }
         [HttpGet("refreshToken")]
        public ActionResult <Token> RefreshToken([FromQuery] String token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context,_configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }
    }
}