using FluentValidation;

namespace WebApi.Application.GenreOpreations.CreateGenre
{
    public class CreaateGenreCommadValidator : AbstractValidator<CreateGenreCommad>
    {
        // constructor aracılığıyla validasyon yapıyor. O yüzden bir constructor yaratıyoruz
        public CreaateGenreCommadValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
