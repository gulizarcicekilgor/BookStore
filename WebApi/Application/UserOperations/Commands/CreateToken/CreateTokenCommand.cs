using AutoMapper;
using WebApi.TokenOperations;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.UserOpreations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model {get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand(IBookStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }
        public Token Handle()
        { //bu user databasede var mı
            var user = _dbContext.Users.FirstOrDefault(u=>u.Email == Model.Email && u.Password ==Model.Password);
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();
                return token;
               
            }
            else
                throw new InvalidOperationException("Kullanıcı zaten var ");

        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}