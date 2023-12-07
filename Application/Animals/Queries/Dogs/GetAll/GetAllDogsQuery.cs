using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Animals.Queries.Dogs.GetAll
{
    public class GetAllDogsQuery : IRequest<DbSet<Dog>>
    {
    }
}
