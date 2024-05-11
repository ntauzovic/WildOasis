using MediatR;
using WildOasis.Application.Common.Dto.Auth;
using WildOasis.Application.Common.Interfaces;

namespace WildOasis.Application.Auth.Command.BeginLoginCommand;

public record BeginLoginCommand(string EmailAddress): IRequest<BeginLoginResponseDto>;

public  class BeginLoginHandler(IAuthService authService): IRequestHandler<BeginLoginCommand,BeginLoginResponseDto>
{
    public async Task<BeginLoginResponseDto> Handle(BeginLoginCommand request, CancellationToken cancellationToken) =>
        await authService.BeginLoginAsync(request.EmailAddress);
}