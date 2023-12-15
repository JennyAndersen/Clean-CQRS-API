using Application.Validators;
using FluentValidation;
using MediatR;

namespace Application.Animals.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest<bool>, IValidate
    {
        public DeleteDogByIdCommand(Guid deletedDogId)
        {
            DeletedDogId = deletedDogId;
        }
        public Guid DeletedDogId { get; }

        public void Validate()
        {
            var validator = new GuidValidator();
            var result = validator.Validate(DeletedDogId);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
