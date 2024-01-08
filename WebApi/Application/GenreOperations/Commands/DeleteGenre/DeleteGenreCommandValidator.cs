using FluentValidation;

namespace WebApi.Application.GenreOpreations.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        // constructor aracılığıyla validasyon yapıyor. O yüzden bir constructor yaratıyoruz
        public DeleteGenreCommandValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}
