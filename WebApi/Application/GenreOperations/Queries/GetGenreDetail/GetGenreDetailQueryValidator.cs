using FluentValidation;

namespace WebApi.Application.GenreOpreations.Queries.GenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        // constructor aracılığıyla validasyon yapıyor. O yüzden bir constructor yaratıyoruz
        public GetGenreDetailQueryValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}
