using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Exceptions
{
    public class MemberEntityException : AppException
    {
        public MemberEntityException(string? message) : base(message)
        {
        }
    }
}
