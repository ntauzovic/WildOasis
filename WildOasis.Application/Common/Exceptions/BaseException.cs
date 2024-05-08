namespace WildOasis.Application.Common.Exceptions;

public class BaseException : Exception
{
    public object? AdditionalData { get; }

    public BaseException(string message, object? additionalData = null) : base(message)
    {
        
    }
}