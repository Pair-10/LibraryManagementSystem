using Application.Features.Returneds.Commands.Create;
using Application.Features.Returneds.Commands.Delete;
using Application.Features.Returneds.Commands.Update;
using Application.Features.Returneds.Queries.GetById;
using Application.Features.Returneds.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReturnedsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateReturnedCommand createReturnedCommand)
    {
        CreatedReturnedResponse response = await Mediator.Send(createReturnedCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateReturnedCommand updateReturnedCommand)
    {
        UpdatedReturnedResponse response = await Mediator.Send(updateReturnedCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedReturnedResponse response = await Mediator.Send(new DeleteReturnedCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdReturnedResponse response = await Mediator.Send(new GetByIdReturnedQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListReturnedQuery getListReturnedQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListReturnedListItemDto> response = await Mediator.Send(getListReturnedQuery);
        return Ok(response);
    }
}