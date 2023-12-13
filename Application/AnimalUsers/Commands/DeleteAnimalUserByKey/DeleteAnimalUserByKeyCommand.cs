using MediatR;

namespace Application.AnimalUsers.Commands.DeleteAnimalUserByKey
{
    public class DeleteAnimalUserByKeyCommand : IRequest<bool>
    {
        public DeleteAnimalUserByKeyCommand(Guid deletedAnimalUserKey)
        {
            DeletedAnimalUserKey = deletedAnimalUserKey;
        }
        public Guid DeletedAnimalUserKey { get; }
    }
}
