using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Animals.Commands.Dogs.AddDog
{
    public class AddDogCommand : IRequest<Dog>
    {
        public AddDogCommand(DogDto newDog)
        {
            NewDog = newDog;
        }

        public DogDto NewDog { get; }
    }
}
