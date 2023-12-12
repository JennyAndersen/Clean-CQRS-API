using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Animals.Queries.Dogs.GetByWeightBreed
{
        public class GetDogsByWeightBreedQuery : IRequest<List<Dog>>
        {
            public int? Weight { get; set; }
            public string? Breed { get; set; }
        }
}
