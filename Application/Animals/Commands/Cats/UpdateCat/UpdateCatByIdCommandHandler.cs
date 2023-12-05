using Domain.Models;
using Infrastructure.Data;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly DataDbContext _dataDbContext;

        public UpdateCatByIdCommandHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        public async Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = _dataDbContext.Cats.FirstOrDefault(cat => cat.Id == request.Id)! ?? throw new NotFoundException($"Bird with ID {request.Id} not found.");

            catToUpdate.Name = request.UpdatedCat.Name;
            catToUpdate.LikesToPlay = request.UpdatedCat.LikesToPlay;
            await _dataDbContext.SaveChangesAsync(cancellationToken);

            return catToUpdate;
        }
    }
}