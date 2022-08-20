using FluentValidation;
using System;

namespace WebApi.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.Model.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(b => b.Model.LastName).NotEmpty().MinimumLength(2);
            RuleFor(a=>a.Model.BirthDate).LessThan(DateTime.Now.AddYears(-18)).NotEmpty();
        }
    }
}
