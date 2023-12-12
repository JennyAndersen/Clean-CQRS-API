using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Animals.Queries.Cats.GetByWeightBreed
{
    public class GetCatsByWeightBreedQuery : IRequest<List<Cat>>
    {
        public int? Weight { get; set; }
        public string? Breed { get; set; }
    }
}
