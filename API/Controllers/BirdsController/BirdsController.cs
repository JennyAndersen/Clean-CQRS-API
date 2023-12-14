using Application.Animals.Commands.Birds.AddBird;
using Application.Animals.Commands.Birds.DeleteBird;
using Application.Animals.Commands.Birds.UpdateBird;
using Application.Animals.Queries.Birds.GetAll;
using Application.Animals.Queries.Birds.GetByColor;
using Application.Animals.Queries.Birds.GetById;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public BirdsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            var birds = await _mediator.Send(new GetAllBirdsQuery());
            return birds == null ? NotFound("No birds found.") : Ok(birds);
        }

        [HttpGet]
        [Route("getBirdById/{birdId}")]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            var bird = await _mediator.Send(new GetBirdByIdQuery(birdId));
            return bird == null ? NotFound($"No bird found with ID '{birdId}'.") : Ok(bird);
        }

        [HttpGet]
        [Route("getBirdByColor/{color}")]
        public async Task<IActionResult> GetBirdsByColor(String color)
        {
            var birds = await _mediator.Send(new GetBirdsByColorQuery { Color = color });
            return (birds == null || !birds.Any()) ? NotFound($"No birds found with color '{color}'.") : Ok(birds);
        }

        [HttpPost]
        [Route("addNewBird")]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            var result = await _mediator.Send(new AddBirdCommand(newBird));
            return result == null ? BadRequest("Could not add the bird.") : Ok(newBird);
        }

        [HttpPut]
        [Route("updateBird/{updatedBirdId}")]
        // [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            var result = await _mediator.Send(new UpdateBirdByIdCommand(updatedBird, updatedBirdId));
            return result == null ? NotFound($"No bird found with ID '{updatedBirdId}' for updating.") : Ok(updatedBird);
        }

        [HttpDelete]
        [Route("deleteBird/{deletedBirdId}")]
        // [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteBird(Guid deletedBirdId)
        {
            var result = await _mediator.Send(new DeleteBirdByIdCommand(deletedBirdId));
            return result == false ? NotFound($"No bird found with ID '{deletedBirdId}' for deletion.") : Ok($"Bird with ID '{deletedBirdId}' has been deleted.");
        }
    }
}
