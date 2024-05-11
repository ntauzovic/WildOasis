namespace WildOasis.Application.Common.Dto.Auth;

public record CompleteLoginResponseDto(string? EmailAddres = null, string? JwtToken = null, List<string>Roles = null);