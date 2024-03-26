using Application.Features.Types.Commands.Create;
using Application.Features.Types.Commands.Delete;
using Application.Features.Types.Commands.Update;
using Application.Features.Types.Queries.GetById;
using Application.Features.Types.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTypeCommand createTypeCommand)
    {
        CreatedTypeResponse response = await Mediator.Send(createTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTypeCommand updateTypeCommand)
    {
        UpdatedTypeResponse response = await Mediator.Send(updateTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTypeResponse response = await Mediator.Send(new DeleteTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTypeResponse response = await Mediator.Send(new GetByIdTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTypeQuery getListTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTypeListItemDto> response = await Mediator.Send(getListTypeQuery);
        return Ok(response);
    }
}