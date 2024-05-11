using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WildOasis.Application.Role.Commands;

namespace WilaOasis.Api.Controllers;

public class RoleController : ApiBaseController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> CreateRole(CreateRoleCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}