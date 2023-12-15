using Application.Validators;
using FluentValidation;
using MediatR;

namespace Application.AnimalUsers.Commands.DeleteAnimalUserByKey
{
    public class DeleteAnimalUserByKeyCommand : IRequest<bool>, IValidate
    {
        public DeleteAnimalUserByKeyCommand(Guid deletedAnimalUserKey)
        {
            DeletedAnimalUserKey = deletedAnimalUserKey;
        }
        public Guid DeletedAnimalUserKey { get; }

        public void Validate()
        {
            var validator = new GuidValidator();
            var result = validator.Validate(DeletedAnimalUserKey);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
