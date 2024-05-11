using WildOasis.Application.Common.Dto.Auth;

namespace WildOasis.Application.Common.Interfaces;

public interface IAuthService
{
    Task<BeginLoginResponseDto> BeginLoginAsync(string emailAddress);

    Task<CompleteLoginResponseDto> CompleteLoginAsync(string token);
}