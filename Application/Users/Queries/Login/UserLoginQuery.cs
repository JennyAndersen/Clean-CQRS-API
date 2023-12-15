using Application.Exceptions;
using Application.Validators;
using MediatR;

namespace Application.Authentication.Queries.Login
{
    public class UserLoginQuery : IRequest<string>, IValidate
    {
        public required string Username { get; set; }
        public required string Password { get; set; }

        public void Validate()
        {
            var validationErrors = new List<string>();

            if (string.IsNullOrEmpty(Username))
            {
                validationErrors.Add("Username cannot be empty.");
            }

            if (string.IsNullOrEmpty(Password))
            {
                validationErrors.Add("Password cannot be empty.");
            }

            if (validationErrors.Count > 0)
            {
                throw new BadRequestException("Validation failed", validationErrors);
            }
        }
    }
}
