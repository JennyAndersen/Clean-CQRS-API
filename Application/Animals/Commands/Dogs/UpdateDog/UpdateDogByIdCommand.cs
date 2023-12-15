using Application.Dtos;
using Application.Validators;
using Domain.Models.Animal;
using FluentValidation;
using MediatR;

namespace Application.Animals.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommand : IRequest<Dog>, IValidate
    {
        public UpdateDogByIdCommand(DogDto updatedDog, Guid id)
        {
            UpdatedDog = updatedDog;
            Id = id;
        }

        public DogDto UpdatedDog { get; }
        public Guid Id { get; }

        public void Validate()
        {
            var guidValidator = new GuidValidator();
            var guidResult = guidValidator.Validate(Id);

            if (!guidResult.IsValid)
            {
                throw new ValidationException(guidResult.Errors);
            }

            var dogValidator = new DogValidator();
            var dogResult = dogValidator.Validate(UpdatedDog);

            if (!dogResult.IsValid)
            {
                throw new ValidationException(dogResult.Errors);
            }
        }
    }
}
