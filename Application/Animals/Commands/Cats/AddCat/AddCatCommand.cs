using Application.Dtos;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Commands.Cats.AddCat
{
    public class AddCatCommand : IRequest<Cat>
    {
        public AddCatCommand(CatDto newCat)
        {
            NewCat = newCat;
        }

        public CatDto NewCat { get; }
    }
}
