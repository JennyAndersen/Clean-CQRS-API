using Application.Animals.Commands.Dogs.AddDog;
using Application.Animals.Commands.Dogs.DeleteDog;
using Application.Animals.Commands.Dogs.UpdateDog;
using Application.Animals.Queries.Dogs.GetAll;
using Application.Animals.Queries.Dogs.GetById;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.DogsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            return Ok(await _mediator.Send(new GetAllDogsQuery()));
        }

        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            return Ok(await _mediator.Send(new GetDogByIdQuery(dogId)));
        }

        [HttpPost]
        [Route("addNewDog")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            return Ok(await _mediator.Send(new AddDogCommand(newDog)));
        }

        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            return Ok(await _mediator.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId)));
        }

        [HttpDelete]
        [Route("deleteDog/{deletedDogId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteDog([FromBody] DogDto deletedDog, Guid deletedDogId)
        {
            return Ok(await _mediator.Send(new DeleteDogByIdCommand(deletedDog, deletedDogId)));
        }
    }
}
