using Application.Features.UserNotifications.Commands.Create;
using Application.Features.UserNotifications.Commands.Delete;
using Application.Features.UserNotifications.Commands.Update;
using Application.Features.UserNotifications.Queries.GetById;
using Application.Features.UserNotifications.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserNotificationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserNotificationCommand createUserNotificationCommand)
    {
        CreatedUserNotificationResponse response = await Mediator.Send(createUserNotificationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserNotificationCommand updateUserNotificationCommand)
    {
        UpdatedUserNotificationResponse response = await Mediator.Send(updateUserNotificationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserNotificationResponse response = await Mediator.Send(new DeleteUserNotificationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserNotificationResponse response = await Mediator.Send(new GetByIdUserNotificationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserNotificationQuery getListUserNotificationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserNotificationListItemDto> response = await Mediator.Send(getListUserNotificationQuery);
        return Ok(response);
    }
}