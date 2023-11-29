using Domain.Models;
using Infrastructure.Database;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateCatByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == request.Id)! ?? throw new NotFoundException($"Bird with ID {request.Id} not found.");

            catToUpdate.Name = request.UpdatedCat.Name;
            catToUpdate.LikesToPlay = request.UpdatedCat.LikesToPlay;

            return Task.FromResult(catToUpdate);
        }
    }
}