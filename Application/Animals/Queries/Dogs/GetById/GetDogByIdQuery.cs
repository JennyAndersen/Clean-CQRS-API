using Application.Validators;
using Domain.Models.Animal;
using FluentValidation;
using MediatR;

namespace Application.Animals.Queries.Dogs.GetById
{
    public class GetDogByIdQuery : IRequest<Dog>, IValidate
    {
        public GetDogByIdQuery(Guid dogId)
        {
            AnimalId = dogId;
        }

        public Guid AnimalId { get; }

        public void Validate()
        {
            var validator = new GuidValidator();
            var result = validator.Validate(AnimalId);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
