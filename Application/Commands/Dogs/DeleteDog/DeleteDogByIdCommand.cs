using Application.Dtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest<bool>
    {
        public DeleteDogByIdCommand(DogDto deletedDog, Guid deletedDogId)
        {
            DeletedDog = deletedDog;
            DeletedDogId = deletedDogId;
        }
        public DogDto DeletedDog { get; }
        public Guid DeletedDogId { get; }
    }
}
