using FluentValidation;

namespace WebApi.Application.AuthorOpreations.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        // constructor aracılığıyla validasyon yapıyor. O yüzden bir constructor yaratıyoruz
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Model.Surname).MinimumLength(4);
        }
    }
}
