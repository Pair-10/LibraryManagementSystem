using Application.Features.Returns.Commands.Create;
using Application.Features.Returns.Commands.Delete;
using Application.Features.Returns.Commands.Update;
using Application.Features.Returns.Queries.GetById;
using Application.Features.Returns.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReturnsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateReturnCommand createReturnCommand)
    {
        CreatedReturnResponse response = await Mediator.Send(createReturnCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateReturnCommand updateReturnCommand)
    {
        UpdatedReturnResponse response = await Mediator.Send(updateReturnCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedReturnResponse response = await Mediator.Send(new DeleteReturnCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdReturnResponse response = await Mediator.Send(new GetByIdReturnQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListReturnQuery getListReturnQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListReturnListItemDto> response = await Mediator.Send(getListReturnQuery);
        return Ok(response);
    }
}