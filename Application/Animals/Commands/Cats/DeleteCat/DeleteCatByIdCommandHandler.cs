using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Database;
using MediatR;

namespace Application.Animals.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, bool>
    {
        private readonly DataDbContext _dataDbContext;
        public DeleteCatByIdCommandHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public async Task<bool> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToDelete = _dataDbContext.Cats.FirstOrDefault(cat => cat.Id == request.DeletedCatId)!;

            if (catToDelete == null)
            {
                return false; 
            }

            _dataDbContext.Cats.Remove(catToDelete);
            await _dataDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}