using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Animals.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, bool>
    {
        private readonly MockDatabase _mockDatabase;
        public DeleteDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<bool> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.DeletedDogId)!;

            if (dogToDelete == null)
            {
                return Task.FromResult(false);
            }

            _mockDatabase.Dogs.Remove(dogToDelete);
            return Task.FromResult(true);
        }
    }
}
