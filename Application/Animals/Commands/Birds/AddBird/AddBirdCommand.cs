using Application.Dtos;
using Application.Validators;
using Domain.Models.Animal;
using FluentValidation;
using MediatR;

namespace Application.Animals.Commands.Birds.AddBird
{
    public class AddBirdCommand : IRequest<Bird>, IValidate
    {
        public AddBirdCommand(BirdDto newBird)
        {
            NewBird = newBird;
        }

        public BirdDto NewBird { get; }

        public void Validate()
        {
            var validator = new BirdValidator();
            var result = validator.Validate(NewBird);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
