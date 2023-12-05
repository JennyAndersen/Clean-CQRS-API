using Application.Animals.Commands.Birds.AddBird;
using Application.Animals.Commands.Birds.DeleteBird;
using Application.Animals.Commands.Birds.UpdateBird;
using Application.Animals.Queries.Birds.GetAll;
using Application.Animals.Queries.Birds.GetById;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        private readonly DataDbContext _dbContext;
        public BirdsController(IMediator mediator, DataDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            return Ok(await _mediator.Send(new GetAllBirdsQuery()));
        }

        [HttpGet]
        [Route("getBirdById/{birdId}")]
        public async Task<IActionResult> GetBirdById(Guid catId)
        {
            return Ok(await _mediator.Send(new GetBirdByIdQuery(catId)));
        }

        [HttpPost]
        [Route("addNewBird")]
        //Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            try
            {
                var result = await _mediator.Send(new AddBirdCommand(newBird));
                return result == null ? BadRequest("Could not add the bird.") : (IActionResult)Ok(newBird);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while adding the bird.");
            }
        }

        [HttpPut]
        [Route("updateBird/{updatedBirdId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            return Ok(await _mediator.Send(new UpdateBirdByIdCommand(updatedBird, updatedBirdId)));
        }

        [HttpDelete]
        [Route("deleteBird/{deletedBirdId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteBird([FromBody] BirdDto deletedBird, Guid deletedBirdId)
        {
            return Ok(await _mediator.Send(new DeleteBirdByIdCommand(deletedBird, deletedBirdId)));
        }
    }
}
