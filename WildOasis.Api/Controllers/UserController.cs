using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WildOasis.Application.User.Command;

namespace WilaOasis.Api.Controllers;


    public class UserController : ApiBaseController
    {
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
