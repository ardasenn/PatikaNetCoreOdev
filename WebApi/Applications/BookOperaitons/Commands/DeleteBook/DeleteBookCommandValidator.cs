using FluentValidation;
using WebApi.BookOperaitons.DeleteBook;

namespace WebApi.Applications.BookOperaitons.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("Boş olamaz").GreaterThan(0).WithMessage("Sıfırdan büyük olmalı");
            
        }
    }
}
