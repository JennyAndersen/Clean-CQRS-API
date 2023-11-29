using Domain.Models;
using Infrastructure.Database;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Queries.Cats.GetById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public GetCatByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == request.Id)! ?? throw new NotFoundException("Cat not found.");
            return Task.FromResult(wantedCat);
        }
    }
}