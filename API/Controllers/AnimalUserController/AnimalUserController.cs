using Application.AnimalUsers.Commands.AddAnimalUser;
using Application.AnimalUsers.Commands.DeleteAnimalUserByKey;
using Application.AnimalUsers.Commands.UpdateAnimalUserByUserID;
using Application.AnimalUsers.Queries.GetAllAnimalUsers;
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

        [HttpGet]
        [Route("getAllAnimalUsers")]
        public async Task<IActionResult> GetAllAnimalUsers()
        {
            return Ok(await _mediator.Send(new GetAllAnimalUsersQuery()));
        }

        [HttpPost]
        [Route("addNewAnimalUser")]
        public async Task<IActionResult> AddAnimalUser([FromBody] AnimalUserDto newAnimalUser)
        {
            return Ok(await _mediator.Send(new AddAnimalUserCommand(newAnimalUser)));
        }

        [HttpPost]
        [Route("updateAnimalUser")]
        public async Task<IActionResult> UpdateAnimalUser([FromBody] UpdateAnimalUserByUserIdCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        [Route("deleteAnimalUser/{deletedAnimalUserKey}")]
        public async Task<IActionResult> DeleteAnimalUser(Guid deletedAnimalUserKey)
        {
            return Ok(await _mediator.Send(new DeleteAnimalUserByKeyCommand(deletedAnimalUserKey)));
        }
    }
}
