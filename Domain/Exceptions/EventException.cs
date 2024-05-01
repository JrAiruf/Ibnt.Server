using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Exceptions
{
    public class EventException : AppException
    {
        public EventException(string? message) : base(message)
        {
        }
    }
}
