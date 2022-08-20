using FluentValidation;

namespace WebApi.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(a => a.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(a => a.Model.Name).MinimumLength(4).When(a => a.Model.Name.Trim() != string.Empty);
        }
    }
}
