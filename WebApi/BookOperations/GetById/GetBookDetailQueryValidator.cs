using FluentValidation;

namespace WebApi.BookOperaitons.GetById
{
   public class  GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
   {
    public GetBookDetailQueryValidator()
    {
        RuleFor(a=>a.BookId).GreaterThanOrEqualTo(0);
    }
   }
}