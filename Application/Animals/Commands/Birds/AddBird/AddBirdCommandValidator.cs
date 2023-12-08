using FluentValidation;

namespace Application.Animals.Commands.Birds.AddBird
{
    public sealed class AddBirdCommandValidator : AbstractValidator<AddBirdCommand>
    {
        public AddBirdCommandValidator()
        {
            RuleFor(command => command.NewBird.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(command => command.NewBird.Color).NotEmpty().WithMessage("Color is required.");
        }
    }
}
