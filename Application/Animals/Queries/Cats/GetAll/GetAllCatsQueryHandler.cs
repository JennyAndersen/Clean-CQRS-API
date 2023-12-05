using Domain.Models;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Animals.Queries.Cats.GetAll
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, DbSet<Cat>>
    {
        private readonly DataDbContext _dataDbContext;

        public GetAllCatsQueryHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public Task<DbSet<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            DbSet<Cat> allCatsFromDatabase = _dataDbContext.Cats;
            return Task.FromResult(allCatsFromDatabase);
        }
    }
}
