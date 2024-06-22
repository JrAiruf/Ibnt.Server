namespace Ibnt.Server.Domain.Exceptions
{
    public abstract class ServiceException : Exception
    {
        public ServiceException(string exception) : base(exception) { }
    }

    public class EmailFormatException : ServiceException
    {
        public EmailFormatException(string exception) : base(exception) { }
    }
}
