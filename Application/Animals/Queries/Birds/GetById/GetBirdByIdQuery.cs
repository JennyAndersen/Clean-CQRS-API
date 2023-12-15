using Application.Validators;
using Domain.Models.Animal;
using FluentValidation;
using MediatR;

namespace Application.Animals.Queries.Birds.GetById
{
    public class GetBirdByIdQuery : IRequest<Bird>, IValidate
    {
        public GetBirdByIdQuery(Guid birdId)
        {
            AnimalId = birdId;
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
