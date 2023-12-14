using MediatR;

namespace Application.AnimalUsers.Commands.UpdateAnimalUserByUserID
{
    public class UpdateAnimalUserByUserIdCommand : IRequest<bool>
    {
        public Guid AnimalUserId { get; }
        public Guid NewUserId { get; }

        public UpdateAnimalUserByUserIdCommand(Guid animalUserId, Guid newUserId)
        {
            AnimalUserId = animalUserId;
            NewUserId = newUserId;
        }
    }
}
