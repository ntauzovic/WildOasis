using MediatR;
using WildOasis.Application.Common.Dto.Auth;
using WildOasis.Application.Common.Interfaces;

namespace WildOasis.Application.Auth.Command.CompleteLoginCommand;

public record CompleteLoginCommand(string ValidationToken) : IRequest<CompleteLoginResponseDto>;

public class CompleteLoginHandler(IAuthService authService) : IRequestHandler<CompleteLoginCommand, CompleteLoginResponseDto>
{
    public async Task<CompleteLoginResponseDto> Handle(CompleteLoginCommand request, CancellationToken cancellationToken) => await authService.CompleteLoginAsync(request.ValidationToken);
}