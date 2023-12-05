using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Database;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Queries.Dogs.GetById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly DataDbContext _dataDbContext;

        public GetDogByIdQueryHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = _dataDbContext.Dogs.FirstOrDefault(dog => dog.Id == request.Id)! ?? throw new NotFoundException("Dog not found.");
            return Task.FromResult(wantedDog);
        }
    }
}
