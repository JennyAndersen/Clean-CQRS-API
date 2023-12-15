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
            try
            {
                var birds = await _mediator.Send(new GetAllBirdsQuery());
                return birds == null ? NotFound("No birds found.") : Ok(birds);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpGet]
        [Route("getBirdById/{birdId}")]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            try
            {
                var bird = await _mediator.Send(new GetBirdByIdQuery(birdId));
                return bird == null ? NotFound($"No bird found with ID '{birdId}'.") : Ok(bird);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpGet]
        [Route("getBirdByColor/{color}")]
        public async Task<IActionResult> GetBirdsByColor(String color)
        {
            try
            {
                var birds = await _mediator.Send(new GetBirdsByColorQuery { Color = color });
                return (birds == null || !birds.Any()) ? NotFound($"No birds found with color '{color}'.") : Ok(birds);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPost]
        [Route("addNewBird")]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            try
            {
                var result = await _mediator.Send(new AddBirdCommand(newBird));
                return result == null ? BadRequest("Could not add the bird.") : Ok(newBird);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPut]
        [Route("updateBird/{updatedBirdId}")]
        // [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            try
            {
                var result = await _mediator.Send(new UpdateBirdByIdCommand(updatedBird, updatedBirdId));
                return result == null ? NotFound($"No bird found with ID '{updatedBirdId}' for updating.") : Ok(updatedBird);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpDelete]
        [Route("deleteBird/{deletedBirdId}")]
        // [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteBird(Guid deletedBirdId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBirdByIdCommand(deletedBirdId));
                return result != null ? Ok($"Bird with ID '{deletedBirdId}' has been deleted.") : NotFound($"No bird found with ID '{deletedBirdId}' for deletion.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }
    }
}
