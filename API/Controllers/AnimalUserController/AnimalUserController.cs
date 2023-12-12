using Application.AnimalUsers.Commands.AddAnimalUser;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AnimalUserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalUserController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public AnimalUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("addNewAnimalUser")]
        public async Task<IActionResult> AddAnimalUser([FromBody] AnimalUserDto newAnimalUser)
        {
            return Ok(await _mediator.Send(new AddAnimalUserCommand(newAnimalUser)));
        }
    }
}
