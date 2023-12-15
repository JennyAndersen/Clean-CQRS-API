using Application.Dtos.MediatR;
using Application.Exceptions;
using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;
using Serilog;

namespace Application.Animals.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, OperationResult<bool>>
    {
        private readonly IAnimalRepository _animalRepository;
        public DeleteBirdByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Animal birdToDelete = await _animalRepository.GetByIdAsync(request.DeletedBirdId) ?? throw new EntityNotFoundException("Bird", request.DeletedBirdId);
                await _animalRepository.DeleteAsync(request.DeletedBirdId);

                Log.Information($"Bird with Id {request.DeletedBirdId} has been successfully deleted.");

                return new OperationResult<bool>
                {
                    IsSuccess = true,
                    Result = true,
                    Message = $"Bird with Id {request.DeletedBirdId} has been successfully deleted."
                };
            }
            catch (EntityNotFoundException ex)
            {
                Log.Error(ex, $"Error deleting bird. Entity not found: {ex.Message}");

                return new OperationResult<bool>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"An error occurred while handling DeleteBirdByIdCommand: {ex.Message}");

                return new OperationResult<bool>
                {
                    IsSuccess = false,
                    ErrorMessage = "An error occurred while handling DeleteBirdByIdCommand"
                };
            }
        }
    }
}