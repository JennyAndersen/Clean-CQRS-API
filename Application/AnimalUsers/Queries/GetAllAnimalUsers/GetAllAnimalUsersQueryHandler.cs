using Domain.Dtos;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.AnimalUsers.Queries.GetAllAnimalUsers
{
    public class GetAllAnimalUsersQueryHandler : IRequestHandler<GetAllAnimalUsersQuery, List<GetAnimalUsersDto>>
    {
        private readonly IAnimalUserRepository _animalUserRepository;
        public GetAllAnimalUsersQueryHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<List<GetAnimalUsersDto>> Handle(GetAllAnimalUsersQuery request, CancellationToken cancellationToken)
        {
            var animalUsers = await _animalUserRepository.GetAllAnimalUsersAsync();

            return animalUsers.Select(au => new GetAnimalUsersDto
            {
                UserName = au.UserName,
                AnimalName = au.AnimalName,
                HappyTogetherIndex = au.HappyTogetherIndex
            }).ToList();
        }
    }
}
