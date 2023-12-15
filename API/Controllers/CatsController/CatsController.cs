using Application.Animals.Commands.Cats.AddCat;
using Application.Animals.Commands.Cats.DeleteCat;
using Application.Animals.Commands.Cats.UpdateCat;
using Application.Animals.Queries.Cats.GetAll;
using Application.Animals.Queries.Cats.GetById;
using Application.Animals.Queries.Cats.GetByWeightBreed;
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
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetAllCats()
        {
            try
            {
                var cats = await _mediator.Send(new GetAllCatsQuery());
                return cats == null ? NotFound("No cats found.") : Ok(cats);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpGet]
        [Route("getCatsByWeightBreed/{weight?}/{breed?}")]
        public async Task<IActionResult> GetCatsByWeightBreed(int? weight, String? breed)
        {
            try
            {
                var cats = await _mediator.Send(new GetCatsByWeightBreedQuery { Weight = weight, Breed = breed });
                return cats == null ? NotFound($"No cats found with weight '{weight}' and breed '{breed}'.") : Ok(cats);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpGet]
        [Route("getCatById/{catId}")]
        public async Task<IActionResult> GetCatById(Guid catId)
        {
            try
            {
                var cat = await _mediator.Send(new GetCatByIdQuery(catId));
                return cat == null ? NotFound($"No cat found with ID '{catId}'.") : Ok(cat);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPost]
        [Route("addNewCat")]
        // [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            try
            {
                var result = await _mediator.Send(new AddCatCommand(newCat));
                return result == null ? BadRequest("Could not add the cat.") : Ok(newCat);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }


        [HttpPut]
        [Route("updateCat/{updatedCatId}")]
        // [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCatByIdCommand(updatedCat, updatedCatId));
                return result == null ? NotFound($"No cat found with ID '{updatedCatId}' for updating.") : Ok(updatedCat);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpDelete]
        [Route("deleteCat/{deletedCatId}")]
        // [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteCat(Guid deletedCatId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCatByIdCommand(deletedCatId));
                return result == false ? NotFound($"No cat found with ID '{deletedCatId}' for deletion.") : Ok($"Cat with ID '{deletedCatId}' has been deleted.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }
    }
}
