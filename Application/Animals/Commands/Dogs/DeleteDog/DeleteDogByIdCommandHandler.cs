using Domain.Models;
using Infrastructure.Data;
using MediatR;

namespace Application.Animals.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, bool>
    {
        private readonly DataDbContext _dataDbContext;
        public DeleteDogByIdCommandHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public async Task<bool> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _dataDbContext.Dogs.FirstOrDefault(dog => dog.Id == request.DeletedDogId)!;

            if (dogToDelete == null)
            {
                return false;
            }

            _dataDbContext.Dogs.Remove(dogToDelete);
            await _dataDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
