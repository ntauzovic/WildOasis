using WildOasis.Application.Common.Exceptions;

namespace WildOasis.Infrastructure.Exceptions;

public class InfrastructureException(string message, object? additionalData = null) : BaseException(message,
    additionalData);