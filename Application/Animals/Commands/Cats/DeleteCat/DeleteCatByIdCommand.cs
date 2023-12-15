using Application.Validators;
using FluentValidation;
using MediatR;

namespace Application.Animals.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommand : IRequest<bool>, IValidate
    {
        public DeleteCatByIdCommand(Guid deletedCatId)
        {
            DeletedCatId = deletedCatId;
        }
        public Guid DeletedCatId { get; }

        public void Validate()
        {
            var validator = new GuidValidator();
            var result = validator.Validate(DeletedCatId);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
