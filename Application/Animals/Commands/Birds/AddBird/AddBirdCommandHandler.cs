using Domain.Models;
using Infrastructure.Data;
using MediatR;

namespace Application.Animals.Commands.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly DataDbContext _dataDbContext;

        public AddBirdCommandHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public async Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewBird.Name,
                CanFly = request.NewBird.CanFly
            };

            _dataDbContext.Birds.Add(birdToCreate);
            await _dataDbContext.SaveChangesAsync(cancellationToken);

            return birdToCreate;
        }
    }
}