using FluentValidation;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(a => a.Model.Name).MinimumLength(4).NotEmpty();
        }
    }
}
