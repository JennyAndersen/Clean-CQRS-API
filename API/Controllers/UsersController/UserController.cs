﻿using Application.Authentication.Commands.Users.Register;
using Application.Authentication.Queries.Users;
using Application.Common;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            try
            {
                var token = await _mediator.Send(new UserLoginQuery
                {
                    Username = model.Username,
                    Password = model.Password
                });

                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto newUser)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _mediator.Send(new RegisterUserCommand(newUser)));
            }
            catch (BadRequestException ex)
            {
                var errorMessage = ex.Errors.FirstOrDefault();

                return BadRequest(new { Error = errorMessage });
            }
        }
    }
}