using Application.Authentication.Commands.DeleteUser;
using Application.Authentication.Commands.Register;
using Application.Authentication.Commands.UpdateUser;
using Application.Authentication.Queries.GetAll;
using Application.Authentication.Queries.Login;
using Application.Dtos;
using Domain.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UsersController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return users == null ? NotFound("No users found.") : Ok(users);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var token = await _mediator.Send(new UserLoginQuery { Username = model.Username, Password = model.Password });
            return model == null ? BadRequest("Invalid login request data.") : Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto newUser)
        {
            var result = await _mediator.Send(new RegisterUserCommand(newUser));
            return newUser == null ? BadRequest("Invalid user registration data.") : Ok(result);
        }

        [HttpPut]
        [Route("updateUser/{updatedUserId}")]
        // [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRegistrationDto updatedUser, Guid updatedUserId)
        {
            var result = await _mediator.Send(new UpdateUserByIdCommand(updatedUser, updatedUserId));
            return result == null ? NotFound($"No user found with ID '{updatedUserId}' for updating.") : Ok(updatedUser);
        }

        [HttpDelete]
        [Route("deleteUser/{deletedUserId}")]
        // [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteUser(Guid deletedUserId)
        {
            var result = await _mediator.Send(new DeleteUserByIdCommand(deletedUserId));
            return result == false ? NotFound($"No user found with ID '{deletedUserId}' for deletion.") : Ok($"User with ID '{deletedUserId}' has been deleted.");
        }
    }
}