using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Database;
using MediatR;

namespace Application.Animals.Commands.Cats.AddCat
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly DataDbContext _dataDbContext;

        public AddCatCommandHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public async Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            Cat catToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewCat.Name,
                LikesToPlay = request.NewCat.LikesToPlay
            };

            _dataDbContext.Cats.Add(catToCreate);
            await _dataDbContext.SaveChangesAsync(cancellationToken);

            return catToCreate; 
        }
    }
}
