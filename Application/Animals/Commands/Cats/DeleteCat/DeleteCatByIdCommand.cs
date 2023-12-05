using Application.Dtos;
using MediatR;

namespace Application.Animals.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommand : IRequest<bool>
    {
        public DeleteCatByIdCommand(Guid deletedCatId)
        {
            DeletedCatId = deletedCatId;
        }
        public Guid DeletedCatId { get; }
    }
}
