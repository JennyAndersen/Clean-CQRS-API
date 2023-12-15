using Application.Dtos;
using Application.Validators;
using Domain.Models.Animal;
using FluentValidation;
using MediatR;

namespace Application.Animals.Commands.Cats.AddCat
{
    public class AddCatCommand : IRequest<Cat>, IValidate
    {
        public AddCatCommand(CatDto newCat)
        {
            NewCat = newCat;
        }

        public CatDto NewCat { get; }

        public void Validate()
        {
            var validator = new CatValidator();
            var result = validator.Validate(NewCat);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
