namespace WildOasis.Application.Common.Exceptions;

public class ExistReservation : BaseException
{
    public ExistReservation(string message, object? additionalData = null) : base(message, additionalData)
    {
    }
}