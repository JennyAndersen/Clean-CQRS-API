using Application.Dtos;
using Application.Validators;
using Domain.Models.Animal;
using FluentValidation;
using MediatR;

namespace Application.Animals.Commands.Birds.UpdateBird
{
    public class UpdateBirdByIdCommand : IRequest<Bird>, IValidate
    {
        public UpdateBirdByIdCommand(BirdDto updatedBird, Guid id)
        {
            UpdatedBird = updatedBird;
            Id = id;
        }

        public BirdDto UpdatedBird { get; }
        public Guid Id { get; }

        public void Validate()
        {
            var guidValidator = new GuidValidator();
            var guidResult = guidValidator.Validate(Id);

            if (!guidResult.IsValid)
            {
                throw new ValidationException(guidResult.Errors);
            }

            var birdValidator = new BirdValidator();
            var birdResult = birdValidator.Validate(UpdatedBird);

            if (!birdResult.IsValid)
            {
                throw new ValidationException(birdResult.Errors);
            }
        }
    }
}