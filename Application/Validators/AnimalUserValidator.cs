using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    internal class AnimalUserValidator : AbstractValidator<AnimalUserDto>
    {
        public AnimalUserValidator()
        {
            Validate();
        }

        public void Validate()
        {
            RuleFor(dto => dto.UserId)
           .NotEmpty().WithMessage("UserId is required.");

            RuleFor(dto => dto.AnimalId)
                .NotEmpty().WithMessage("AnimalId is required.");

            RuleFor(dto => dto.HappyTogetherIndex)
                .InclusiveBetween(1, 100).WithMessage("HappyTogetherIndex must be between 1 and 100.");
        }
    }
}
