using Domain.Models;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Animals.Queries.Dogs.GetAll
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, DbSet<Dog>>
    {
        private readonly DataDbContext _dataDbContext;

        public GetAllDogsQueryHandler(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        public Task<DbSet<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            DbSet<Dog> allDogsFromDatabase = _dataDbContext.Dogs;
            return Task.FromResult(allDogsFromDatabase);
        }
    }
}
