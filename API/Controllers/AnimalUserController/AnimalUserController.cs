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
            try
            {
                var animalUsers = await _mediator.Send(new GetAllAnimalUsersQuery());
                return animalUsers == null ? NotFound("No animalUsers found.") : Ok(animalUsers);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPost]
        [Route("addNewAnimalUser")]
        public async Task<IActionResult> AddAnimalUser([FromBody] AnimalUserDto newAnimalUser)
        {
            try
            {
                var result = await _mediator.Send(new AddAnimalUserCommand(newAnimalUser));
                return result == false ? BadRequest("Could not add the animaluser.") : Ok(newAnimalUser);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPost]
        [Route("updateAnimalUser")]
        public async Task<IActionResult> UpdateAnimalUser([FromBody] UpdateAnimalUserByUserIdCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return command == null ? BadRequest("Invalid update animal user command data.") : Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpDelete]
        [Route("deleteAnimalUser/{deletedAnimalUserKey}")]
        public async Task<IActionResult> DeleteAnimalUser(Guid deletedAnimalUserKey)
        {
            try
            {
                var result = await _mediator.Send(new DeleteAnimalUserByKeyCommand(deletedAnimalUserKey));
                return result == false ? BadRequest("Invalid delete animal user command data.") : Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }
    }
}
