using Application.Validators;
using Domain.Models.Animal;
using FluentValidation;
using MediatR;

namespace Application.Animals.Queries.Cats.GetById
{
    public class GetCatByIdQuery : IRequest<Cat>, IValidate
    {
        public GetCatByIdQuery(Guid catId)
        {
            AnimalId = catId;
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