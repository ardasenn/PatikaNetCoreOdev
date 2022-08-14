using FluentValidation;

namespace WebApi.BookOperaitons.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(a=>a.Model.PageCount).GreaterThan(0);
            RuleFor(a=>a.Model.PublishDate.Date).NotEmpty().LessThan(System.DateTime.Now.Date);
            RuleFor(a=>a.Model.Title).NotEmpty().MinimumLength(4);
            
        }

    }
}