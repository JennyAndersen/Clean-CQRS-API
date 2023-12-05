using Domain.Models;
using Infrastructure.Data;
using MediatR;

namespace Application.Animals.Commands.Dogs.AddDog
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly DataDbContext _dataDbContext;

        public AddDogCommandHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            Dog dogToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewDog.Name
            };

            _dataDbContext.Dogs.Add(dogToCreate);
            await _dataDbContext.SaveChangesAsync(cancellationToken);

            return dogToCreate;
        }
    }
}
