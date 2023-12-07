using Domain.Models;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Animals.Queries.Birds.GetAll
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, DbSet<Bird>>
    {
        private readonly AnimalDbContext _dataDbContext;

        public GetAllBirdsQueryHandler(AnimalDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public Task<DbSet<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            DbSet<Bird> allBirdsFromDatabase = _dataDbContext.Birds;
            return Task.FromResult(allBirdsFromDatabase);
        }
    }
}