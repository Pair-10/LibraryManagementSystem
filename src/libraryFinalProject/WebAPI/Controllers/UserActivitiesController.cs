using Application.Features.UserActivities.Commands.Create;
using Application.Features.UserActivities.Commands.Delete;
using Application.Features.UserActivities.Commands.Update;
using Application.Features.UserActivities.Queries.GetById;
using Application.Features.UserActivities.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserActivitiesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserActivityCommand createUserActivityCommand)
    {
        CreatedUserActivityResponse response = await Mediator.Send(createUserActivityCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserActivityCommand updateUserActivityCommand)
    {
        UpdatedUserActivityResponse response = await Mediator.Send(updateUserActivityCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserActivityResponse response = await Mediator.Send(new DeleteUserActivityCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserActivityResponse response = await Mediator.Send(new GetByIdUserActivityQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserActivityQuery getListUserActivityQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserActivityListItemDto> response = await Mediator.Send(getListUserActivityQuery);
        return Ok(response);
    }
}