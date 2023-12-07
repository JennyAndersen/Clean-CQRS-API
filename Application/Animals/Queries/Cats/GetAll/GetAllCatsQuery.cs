using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Animals.Queries.Cats.GetAll
{
    public class GetAllCatsQuery : IRequest<DbSet<Cat>>
    {
    }
}
