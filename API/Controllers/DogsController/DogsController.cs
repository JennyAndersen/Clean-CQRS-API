using Application.Animals.Commands.Dogs.AddDog;
using Application.Animals.Commands.Dogs.DeleteDog;
using Application.Animals.Commands.Dogs.UpdateDog;
using Application.Animals.Queries.Dogs.GetAll;
using Application.Animals.Queries.Dogs.GetById;
using Application.Animals.Queries.Dogs.GetByWeightBreed;
using Application.Dtos;
using MediatR;
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
            try
            {
                var dogs = await _mediator.Send(new GetAllDogsQuery());
                return dogs == null ? NotFound("No dogs found.") : Ok(dogs);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpGet]
        [Route("getDogByWeightBreed/{weight?}/{breed?}")]
        public async Task<IActionResult> GetDogsByWeightBreed(int? weight, String? breed)
        {
            try
            {
                var dogs = await _mediator.Send(new GetDogsByWeightBreedQuery { Weight = weight, Breed = breed });
                return dogs == null ? NotFound($"No dogs found with weight '{weight}' and breed '{breed}'.") : Ok(dogs);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            try
            {
                var dog = await _mediator.Send(new GetDogByIdQuery(dogId));
                return dog == null ? NotFound($"No dog found with ID '{dogId}'.") : Ok(dog);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            try
            {
                var result = await _mediator.Send(new AddDogCommand(newDog));
                return result == null ? BadRequest("Could not add the dog.") : Ok(newDog);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            try
            {
                var result = await _mediator.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId));
                return result == null ? NotFound($"No dog found with ID '{updatedDogId}' for updating.") : Ok(updatedDog);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpDelete]
        [Route("deleteDog/{deletedDogId}")]
        public async Task<IActionResult> DeleteDog(Guid deletedDogId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteDogByIdCommand(deletedDogId));
                return result == false ? NotFound($"No dog found with ID '{deletedDogId}' for deletion.") : Ok($"Dog with ID '{deletedDogId}' has been deleted.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

    }
}
