using Microsoft.AspNetCore.Mvc;
using WildOasis.Application.Booking.Commands;
using WildOasis.Application.Booking.Queries;
using WildOasis.Application.Cabin.Commands;
using WildOasis.Application.Common.Exceptions;

namespace WilaOasis.Api.Controllers;

public class BookingController : ApiBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(BookingCommmandCreate command) => Ok(await Mediator.Send(command));

    [HttpGet]
    public async Task<IActionResult> DetailsOne([FromQuery] BookingDetailsQuery query)
    {
        var result = await Mediator.Send(query);
        if (result == null)
        {
            throw new NotFoundException("Booking not exist");
        }

        return Ok(result);    }
}