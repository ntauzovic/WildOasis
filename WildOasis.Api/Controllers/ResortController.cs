using Demo.Auth.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WildOasis.Application.Cabin.Commands;
using WildOasis.Application.Cabin.Queries;
using WildOasis.Application.Common.Exceptions;
using WildOasis.Application.Resort.Commands;
using WildOasis.Application.Resort.Queries;
using WildOasis.Infrastructure.Contexts;

namespace WilaOasis.Api.Controllers;

public class ResortController(WildOasisDbContext context) : ApiBaseController
{
    [HttpGet]
    [Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
    public async Task<IActionResult> Details([FromQuery] ResortDetailQuery query)
    {
        var result = await Mediator.Send(query);
        if (result == null)
        {
            throw new NotFoundException("Resort not exist");
        }

        return Ok(result);
        
        
    }
    [HttpGet]
    public async Task<IActionResult> DetailsAll([FromQuery]AllResortDetailsQuery query)
    {
        var result = await Mediator.Send(query);
        if (result == null)
        {
            throw new NotFoundException("dont have any cabins");
        }

        return Ok(result);    }

    
    [HttpPost("create")]

    public async Task<IActionResult> Create(ResortCommandCreate command) => Ok(await Mediator.Send(command));
    
    [HttpPut]
    public async Task<IActionResult> Update(ResortCommandUpdate command) => Ok(await Mediator.Send(command));

    
    [HttpDelete]
    public async Task<IActionResult> Delete(ResortCommmandDelete command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}