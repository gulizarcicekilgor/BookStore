using FluentValidation;

namespace WebApi.Application.GenreOpreations.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        // constructor aracılığıyla validasyon yapıyor. O yüzden bir constructor yaratıyoruz
        public CreateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
