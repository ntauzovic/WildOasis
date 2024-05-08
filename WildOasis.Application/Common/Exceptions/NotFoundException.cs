namespace WildOasis.Application.Common.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string message, object? dditionalData = null) : base(message, dditionalData)
    {
    }
}