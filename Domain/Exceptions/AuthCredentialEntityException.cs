using Ibnt.Server.Domain.Exceptions;

namespace Ibnt.Server.Domain.Exceptions
{
    public class AuthCredentialEntityException : AppException
    {
        public AuthCredentialEntityException(string? message) : base(message)
        {
        }
    }

    public class ExistingUserException : AppException
    {
        public ExistingUserException(string? message) : base(message)
        {
        }
    }
}
