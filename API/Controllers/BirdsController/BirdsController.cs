using Application.Dtos;
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
        public BirdsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            return Ok(await _mediator.Send(new GetAllBirdsQuery()));
        }

        [HttpGet]
        [Route("getBirdById/{catId}")]
        public async Task<IActionResult> GetBirdById(Guid catId)
        {
            return Ok(await _mediator.Send(new GetBirdByIdQuery(catId)));
        }

        [HttpPost]
        [Route("addNewBird")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            return Ok(await _mediator.Send(new AddBirdCommand(newBird)));
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
