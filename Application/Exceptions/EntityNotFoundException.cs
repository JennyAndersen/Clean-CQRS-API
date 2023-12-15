namespace Application.Exceptions
{
    public class EntityNotFoundException : BaseCustomException
    {
        public EntityNotFoundException(string name, object key)
            : base($"Entity {name} with Id of {key} was not found.")
        {
        }
    }
}
