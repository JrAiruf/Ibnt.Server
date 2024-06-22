namespace App.Domain.Exceptions
{
    public class MemberEntityException : AppException
    {
        public MemberEntityException(string? message) : base(message)
        {
        }
    }
}
