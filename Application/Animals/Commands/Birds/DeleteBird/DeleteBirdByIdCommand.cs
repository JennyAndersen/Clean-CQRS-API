using Application.Dtos;
using MediatR;

namespace Application.Animals.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommand : IRequest<bool>
    {
        public DeleteBirdByIdCommand(Guid deletedBirdId)
        {
            DeletedBirdId = deletedBirdId;
        }
        public Guid DeletedBirdId { get; }
    }
}