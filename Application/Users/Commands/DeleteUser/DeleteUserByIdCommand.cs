using MediatR;

namespace Application.Authentication.Commands.DeleteUser
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
