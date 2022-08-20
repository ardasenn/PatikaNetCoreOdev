using FluentValidation;

namespace WebApi.BookOperaitons.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(a=>a.Model.GenreId).GreaterThan(0);
            RuleFor(a=>a.Model.PageCount).GreaterThan(0);
            RuleFor(a=>a.Model.PublishDate.Date).LessThan(System.DateTime.Now.Date);
            RuleFor(a=>a.Model.Title).MinimumLength(3);
        }
    }
}