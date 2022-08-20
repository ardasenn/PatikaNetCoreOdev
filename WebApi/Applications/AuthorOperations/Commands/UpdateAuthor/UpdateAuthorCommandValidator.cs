using FluentValidation;
using System;

namespace WebApi.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(a => a.Model.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(b => b.Model.LastName).NotEmpty().MinimumLength(2);
            RuleFor(a => a.Model.BirthDate).LessThan(DateTime.Now.AddYears(-18)).NotEmpty();
            RuleFor(a => a.Id).GreaterThan(0).NotEmpty();
        }
    }
}
