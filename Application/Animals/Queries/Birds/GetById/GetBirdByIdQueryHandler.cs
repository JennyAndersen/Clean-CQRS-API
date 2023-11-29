using Domain.Models;
using Infrastructure.Database;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Queries.Birds.GetById
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public GetBirdByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = _mockDatabase.Birds.FirstOrDefault(bird => bird.Id == request.Id)! ?? throw new NotFoundException("Bird not found.");
            return Task.FromResult(wantedBird);
        }
    }
}
