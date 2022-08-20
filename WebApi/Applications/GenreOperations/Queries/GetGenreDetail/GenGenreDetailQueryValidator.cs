using FluentValidation;

namespace WebApi.Applications.GenreOperations.Queries.GetGenreDetail
{
    public class GenGenreDetailQueryValidator :AbstractValidator<GenGenreDetailQuery>
    {
        public GenGenreDetailQueryValidator()
        {
            RuleFor(c => c.GenreId).GreaterThanOrEqualTo(0);
        }
    }
}
