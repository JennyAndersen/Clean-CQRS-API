using Application.Validators;
using FluentValidation;
using MediatR;

namespace Application.Authentication.Commands.DeleteUser
{
    public class DeleteUserByIdCommand : IRequest<bool>, IValidate
    {
        public DeleteUserByIdCommand(Guid deletedUserId)
        {
            DeletedUserId = deletedUserId;
        }
        public Guid DeletedUserId { get; }

        public void Validate()
        {
            var validator = new GuidValidator();
            var result = validator.Validate(DeletedUserId);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
