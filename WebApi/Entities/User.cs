using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class User
    {[  DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? RefreshToken { get; set; } //acces tokenin süresi dolduktan sonra access token isteyebilmek için
        public DateTime RefreshTokenExpireDate { get; set; }

    }
}