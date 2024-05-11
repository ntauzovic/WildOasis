using MediatR;
using WildOasis.Application.Common.Interfaces;

namespace WildOasis.Application.Role.Commands;
public record CreateRoleCommand(string Role) : IRequest;

public class CreateRoleCommandHandler(IRoleService roleService) : IRequestHandler<CreateRoleCommand>
{
    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken) => await roleService.CreateRole(request.Role);
}