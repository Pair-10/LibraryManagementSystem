using Application.Features.ActivityNotifications.Commands.Create;
using Application.Features.ActivityNotifications.Commands.Delete;
using Application.Features.ActivityNotifications.Commands.Update;
using Application.Features.ActivityNotifications.Queries.GetById;
using Application.Features.ActivityNotifications.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivityNotificationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateActivityNotificationCommand createActivityNotificationCommand)
    {
        CreatedActivityNotificationResponse response = await Mediator.Send(createActivityNotificationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateActivityNotificationCommand updateActivityNotificationCommand)
    {
        UpdatedActivityNotificationResponse response = await Mediator.Send(updateActivityNotificationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedActivityNotificationResponse response = await Mediator.Send(new DeleteActivityNotificationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdActivityNotificationResponse response = await Mediator.Send(new GetByIdActivityNotificationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListActivityNotificationQuery getListActivityNotificationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListActivityNotificationListItemDto> response = await Mediator.Send(getListActivityNotificationQuery);
        return Ok(response);
    }
}