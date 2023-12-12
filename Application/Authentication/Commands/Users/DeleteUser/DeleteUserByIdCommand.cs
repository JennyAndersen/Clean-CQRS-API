using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Users.DeleteUser
{
    public class DeleteUserByIdCommand : IRequest<bool>
    {
        public DeleteUserByIdCommand(Guid deletedUserId)
        {
            DeletedUserId = deletedUserId;
        }
        public Guid DeletedUserId { get; }
    }
}
