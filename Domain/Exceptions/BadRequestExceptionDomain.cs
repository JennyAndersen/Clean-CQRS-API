namespace Domain.Exceptions
{
    public abstract class BadRequestExceptionDomain : ApplicationException
    {
        protected BadRequestExceptionDomain(string message)
            : base("Bad Request", message)
        {
        }
    }
}
