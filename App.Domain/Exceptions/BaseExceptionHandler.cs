namespace App.Domain.Exceptions
{
    public abstract class BaseExceptionHandler<E> : AppExceptionHandler<E> where E : AppException
    {
        public AppException Handle(E exception)
        {
            return exception;
        }
    }

    public interface AppExceptionHandler<T>
    {
        AppException Handle(T exception);
    }
}
