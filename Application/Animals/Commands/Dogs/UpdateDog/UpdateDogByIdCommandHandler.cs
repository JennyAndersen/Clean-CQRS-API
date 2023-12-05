using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Database;
using MediatR;

namespace Application.Animals.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly DataDbContext _dataDbContext;

        public UpdateDogByIdCommandHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToUpdate = _dataDbContext.Dogs.FirstOrDefault(dog => dog.Id == request.Id)!;

            dogToUpdate.Name = request.UpdatedDog.Name;
            await _dataDbContext.SaveChangesAsync(cancellationToken);

            return dogToUpdate;
        }
    }
}
