//comnect token endpoint
//geriye dönecek acces token tutulacak
namespace WebApi.TokenOperations.Models
{
    public class Token{
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}