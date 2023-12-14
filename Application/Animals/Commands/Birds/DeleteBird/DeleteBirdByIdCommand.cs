using Application.Validators;
using FluentValidation;
using MediatR;

namespace Application.Animals.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommand : IRequest<bool>, IValidate
    {
        public DeleteBirdByIdCommand(Guid deletedBirdId)
        {
            DeletedBirdId = deletedBirdId;
        }
        public Guid DeletedBirdId { get; }

        public void Validate()
        {
            var validator = new GuidValidator();
            var result = validator.Validate(DeletedBirdId);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}