using Application.Dtos;
using Application.Validators;
using Domain.Models.Animal;
using FluentValidation;
using MediatR;

namespace Application.Animals.Commands.Dogs.AddDog
{
    public class AddDogCommand : IRequest<Dog>, IValidate
    {
        public AddDogCommand(DogDto newDog)
        {
            NewDog = newDog;
        }

        public DogDto NewDog { get; }

        public void Validate()
        {
            var validator = new DogValidator();
            var result = validator.Validate(NewDog);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
