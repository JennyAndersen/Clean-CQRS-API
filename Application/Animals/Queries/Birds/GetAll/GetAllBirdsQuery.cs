using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Animals.Queries.Birds.GetAll
{
    public class GetAllBirdsQuery : IRequest<DbSet<Bird>>
    {
    }
}
