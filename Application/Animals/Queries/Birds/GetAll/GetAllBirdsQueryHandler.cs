using Domain.Models;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Animals.Queries.Birds.GetAll
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, DbSet<Bird>>
    {
        private readonly DataDbContext _dataDbContext;

        public GetAllBirdsQueryHandler(DataDbContext dataDbContext)
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