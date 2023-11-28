using Application.Animals.Commands.Cats.AddCat;
using Application.Animals.Commands.Cats.DeleteCat;
using Application.Animals.Commands.Cats.UpdateCat;
using Application.Animals.Queries.Cats.GetAll;
using Application.Animals.Queries.Cats.GetById;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public CatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            return Ok(await _mediator.Send(new GetAllCatsQuery()));
        }

        [HttpGet]
        [Route("getCatById/{catId}")]
        public async Task<IActionResult> GetCatById(Guid catId)
        {
            return Ok(await _mediator.Send(new GetCatByIdQuery(catId)));
        }

        [HttpPost]
        [Route("addNewCat")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            return Ok(await _mediator.Send(new AddCatCommand(newCat)));
        }


        [HttpPut]
        [Route("updateCat/{updatedCatId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            return Ok(await _mediator.Send(new UpdateCatByIdCommand(updatedCat, updatedCatId)));
        }

        [HttpDelete]
        [Route("deleteCat/{deletedCatId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteCat([FromBody] CatDto deletedCat, Guid deletedCatId)
        {
            return Ok(await _mediator.Send(new DeleteCatByIdCommand(deletedCat, deletedCatId)));
        }
    }
}
