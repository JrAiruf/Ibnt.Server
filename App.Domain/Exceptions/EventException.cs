namespace App.Domain.Exceptions
{
    public class EventException : AppException
    {
        public EventException(string? message) : base(message)
        {
        }
    }
}
