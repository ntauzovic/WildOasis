using Microsoft.AspNetCore.Mvc;
using WildOasis.Application.Cabin.Commands;
using WildOasis.Application.Cabin.Queries;
using WildOasis.Application.Common.Exceptions;
using WildOasis.Infrastructure.Contexts;

namespace WilaOasis.Api.Controllers;

public class CabinController(WildOasisDbContext context) : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> DetailsOne([FromQuery] CabinDetailsQuery query)
    {
        var result = await Mediator.Send(query);
        if (result == null)
        {
            throw new NotFoundException("Cabin not exist");
        }

        return Ok(result);    }
    
    [HttpGet]
    public async Task<IActionResult> DetailsAll([FromQuery]AllCabinDetailsQuery query)
    {
        var result = await Mediator.Send(query);
        if (result == null)
        {
            throw new NotFoundException("dont have any cabins");
        }

        return Ok(result);    }

    [HttpPost]
    public async Task<IActionResult> Create(CabinCommandCreate command) => Ok(await Mediator.Send(command));
    
    [HttpPut]
    public async Task<IActionResult> Update(CabinCommandUpdate command) => Ok(await Mediator.Send(command));

    
    [HttpDelete]
    public async Task<IActionResult> Delete(CabinCommmandDelete command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
}