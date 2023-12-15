using Application.Validators;
using Domain.Models.Animal;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Queries.Birds.GetByColor
{
    public class GetBirdsByColorQuery : IRequest<List<Bird>>, IValidate
    {
        public required string Color { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Color))
            {
                throw new BadRequestException("Username cannot be empty.");
            }
        }
    }
}
