using Application.Dtos;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Commands.Birds.UpdateBird
{
    public class UpdateBirdByIdCommand : IRequest<Bird>
    {
        public UpdateBirdByIdCommand(BirdDto updatedBird, Guid id)
        {
            UpdatedBird = updatedBird;
            Id = id;
        }

        public BirdDto UpdatedBird { get; }
        public Guid Id { get; }
    }
}