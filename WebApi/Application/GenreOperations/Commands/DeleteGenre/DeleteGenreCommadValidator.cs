using FluentValidation;

namespace WebApi.Application.GenreOpreations.DeleteGenre
{
    public class DeleteGenreCommadValidator : AbstractValidator<DeleteGenreCommad>
    {
        // constructor aracılığıyla validasyon yapıyor. O yüzden bir constructor yaratıyoruz
        public DeleteGenreCommadValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}
