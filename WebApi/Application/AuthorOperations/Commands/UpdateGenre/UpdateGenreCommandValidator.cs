using FluentValidation;

namespace WebApi.Application.AuthorOpreations.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            //minimumlengt 4 olsun ama boş gelmezse 4 olsun. minimumlengt kuralını bir koşula bağladık
            RuleFor(x => x.Model.Name).MinimumLength(4).When(x => x.Model.Name != string.Empty);
            RuleFor(x => x.Model.Surname).MinimumLength(4).When(x => x.Model.Surname != string.Empty);
            
        }
    }
}
