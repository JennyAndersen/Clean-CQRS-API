using Application.Dtos;
using MediatR;

namespace Application.Animals.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommand : IRequest<bool>
    {
        public DeleteBirdByIdCommand(BirdDto deletedBird, Guid deletedBirdId)
        {
            DeletedBird = deletedBird;
            DeletedBirdId = deletedBirdId;
        }
        public BirdDto DeletedBird { get; }
        public Guid DeletedBirdId { get; }
    }
}