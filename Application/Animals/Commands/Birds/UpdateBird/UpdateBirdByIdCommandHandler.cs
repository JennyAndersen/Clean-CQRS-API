using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Database;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Commands.Birds.UpdateBird
{
    public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIdCommand, Bird>
    {
        private readonly DataDbContext _dataDbContext;

        public UpdateBirdByIdCommandHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        public async Task<Bird> Handle(UpdateBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToUpdate = _dataDbContext.Birds.FirstOrDefault(bird => bird.Id == request.Id)! ?? throw new NotFoundException($"Bird with ID {request.Id} not found.");

            birdToUpdate.Name = request.UpdatedBird.Name;
            birdToUpdate.CanFly = request.UpdatedBird.CanFly;
            await _dataDbContext.SaveChangesAsync();

            return birdToUpdate;
        }
    }
}