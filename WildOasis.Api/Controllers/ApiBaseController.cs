using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WilaOasis.Api.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class ApiBaseController : ControllerBase
{
    private ISender? _mediator;
    
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    //iSender ako je mediator null pokupice sve servise isender u kji se nalazi u request senderu
    //

}