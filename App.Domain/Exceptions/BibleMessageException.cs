namespace App.Domain.Exceptions
{
    public class BibleMessageException : AppException
    {
        public BibleMessageException(string exception) : base(exception) { }
    }
}
