using Application.Dtos;
using MediatR;

namespace Application.AnimalUsers.Commands.AddAnimalUser
{
    public class AddAnimalUserCommand : IRequest<bool>
    {
        public AddAnimalUserCommand(AnimalUserDto animalUserDto)
        {
            UserId = animalUserDto.UserId;
            AnimalId = animalUserDto.AnimalId;
            HappyTogetherIndex = animalUserDto.HappyTogetherIndex;
        }

        public Guid UserId { get; }
        public Guid AnimalId { get; }
        public int HappyTogetherIndex { get; }
    }
}
