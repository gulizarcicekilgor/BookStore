using FluentValidation;

namespace WebApi.Application.GenreOpreations.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            //minimumlengt 4 olsun ama boş gelmezse 4 olsun. minimumlengt kuralını bir koşula bağladık
            RuleFor(x => x.Model.Name).MinimumLength(4).When(x => x.Model.Name != string.Empty);
        }
    }
}
