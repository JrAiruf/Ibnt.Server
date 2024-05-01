using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Exceptions
{
    public class TimeLineContentException : AppException
    {
        public TimeLineContentException(string? message) : base(message)
        {
        }
    }
}
