using Application.Features.Activities.Commands.Create;
using Application.Features.Activities.Commands.Delete;
using Application.Features.Activities.Commands.Update;
using Application.Features.Activities.Queries.GetById;
using Application.Features.Activities.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivitiesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateActivityCommand createActivityCommand)
    {
        CreatedActivityResponse response = await Mediator.Send(createActivityCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateActivityCommand updateActivityCommand)
    {
        UpdatedActivityResponse response = await Mediator.Send(updateActivityCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedActivityResponse response = await Mediator.Send(new DeleteActivityCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdActivityResponse response = await Mediator.Send(new GetByIdActivityQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListActivityQuery getListActivityQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListActivityListItemDto> response = await Mediator.Send(getListActivityQuery);
        return Ok(response);
    }
}