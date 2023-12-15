using Application.Dtos;
using Application.Validators;
using Domain.Models.Animal;
using FluentValidation;
using MediatR;

namespace Application.Animals.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommand : IRequest<Cat>, IValidate
    {
        public UpdateCatByIdCommand(CatDto updatedCat, Guid id)
        {
            UpdatedCat = updatedCat;
            Id = id;
        }

        public CatDto UpdatedCat { get; }
        public Guid Id { get; }

        public void Validate()
        {
            var guidValidator = new GuidValidator();
            var guidResult = guidValidator.Validate(Id);

            if (!guidResult.IsValid)
            {
                throw new ValidationException(guidResult.Errors);
            }

            var catValidator = new CatValidator();
            var catResult = catValidator.Validate(UpdatedCat);

            if (!catResult.IsValid)
            {
                throw new ValidationException(catResult.Errors);
            }
        }
    }
}
