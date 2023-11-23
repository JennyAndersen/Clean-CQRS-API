﻿using Application.Commands.Birds;
using Application.Commands.Birds.DeleteDog;
using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Application.Queries.Birds.GetAll;
using Application.Queries.Birds.GetById;
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
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            return Ok(await _mediator.Send(new AddBirdCommand(newBird)));
        }

        // FIX here 
        [HttpPut]
        [Route("updateBird/{updatedBirdId}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            return Ok(await _mediator.Send(new UpdateBirdByIdCommand(updatedBird, updatedBirdId)));
        }

        [HttpDelete]
        [Route("deleteBird/{deletedBirdId}")]
        public async Task<IActionResult> DeleteBird([FromBody] BirdDto deletedBird, Guid deletedBirdId)
        {
            return Ok(await _mediator.Send(new DeleteBirdByIdCommand(deletedBird, deletedBirdId)));
        }
    }
}
