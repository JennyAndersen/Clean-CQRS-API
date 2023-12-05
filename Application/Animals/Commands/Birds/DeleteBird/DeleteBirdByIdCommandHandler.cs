using Domain.Models;
using Infrastructure.Data;
using MediatR;

namespace Application.Animals.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, bool>
    {
        private readonly DataDbContext _dataDbContext;
        public DeleteBirdByIdCommandHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public async Task<bool> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = _dataDbContext.Birds.FirstOrDefault(bird => bird.Id == request.DeletedBirdId)!;

            if (birdToDelete == null)
            {
                return false;
            }

            _dataDbContext.Birds.Remove(birdToDelete);
            await _dataDbContext.SaveChangesAsync();
            return true;
        }
    }
}