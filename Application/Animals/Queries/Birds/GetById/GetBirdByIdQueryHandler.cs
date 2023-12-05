using Domain.Models;
using Infrastructure.Data;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Queries.Birds.GetById
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {
        private readonly DataDbContext _dataDbContext;

        public GetBirdByIdQueryHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = _dataDbContext.Birds.FirstOrDefault(bird => bird.Id == request.Id)! ?? throw new NotFoundException("Bird not found.");
            return Task.FromResult(wantedBird);
        }
    }
}
