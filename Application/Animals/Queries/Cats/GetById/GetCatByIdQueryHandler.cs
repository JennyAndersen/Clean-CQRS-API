using Domain.Models;
using Infrastructure.Data;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Queries.Cats.GetById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly AnimalDbContext _dataDbContext;

        public GetCatByIdQueryHandler(AnimalDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = _dataDbContext.Cats.FirstOrDefault(cat => cat.Id == request.Id)! ?? throw new NotFoundException("Cat not found.");
            return Task.FromResult(wantedCat);
        }
    }
}