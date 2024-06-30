namespace App.Domain.Exceptions
{
    public class AnnouncementException : AppException
    {
        public AnnouncementException(string? message) : base(message) { }
    }
}
