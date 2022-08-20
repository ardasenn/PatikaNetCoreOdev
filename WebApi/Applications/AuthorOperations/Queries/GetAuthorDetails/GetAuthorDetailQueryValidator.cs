using FluentValidation;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthorDetails
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(a => a.Id).GreaterThan(0);
        }
    }
}
