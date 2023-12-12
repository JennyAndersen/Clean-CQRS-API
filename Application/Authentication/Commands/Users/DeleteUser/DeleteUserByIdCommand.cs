using MediatR;

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
