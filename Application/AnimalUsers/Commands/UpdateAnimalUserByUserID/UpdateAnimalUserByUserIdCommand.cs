using Application.Validators;
using FluentValidation;
using MediatR;

namespace Application.AnimalUsers.Commands.UpdateAnimalUserByUserID
{
    public class UpdateAnimalUserByUserIdCommand : IRequest<bool>, IValidate
    {
        public Guid AnimalUserId { get; }
        public Guid NewUserId { get; }

        public UpdateAnimalUserByUserIdCommand(Guid animalUserId, Guid newUserId)
        {
            AnimalUserId = animalUserId;
            NewUserId = newUserId;
        }

        public void Validate()
        {
            var userValidator = new GuidValidator();
            var userResult = userValidator.Validate(NewUserId);

            if (!userResult.IsValid)
            {
                throw new ValidationException(userResult.Errors);
            }

            var animalValidator = new GuidValidator();
            var animalResult = animalValidator.Validate(AnimalUserId);

            if (!animalResult.IsValid)
            {
                throw new ValidationException(animalResult.Errors);
            }
        }
    }
}
