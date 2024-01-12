using AutoMapper;
using WebApi.TokenOperations;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.UserOpreations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken {get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IBookStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public Token Handle()
        { //bu user databasede var mı
            var user = _dbContext.Users.FirstOrDefault(u=>u.RefreshToken == RefreshToken && u.RefreshTokenExpireDate > DateTime.Now);
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
}