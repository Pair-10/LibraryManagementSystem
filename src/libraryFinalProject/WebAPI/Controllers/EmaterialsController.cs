using Application.Features.Ematerials.Commands.Create;
using Application.Features.Ematerials.Commands.Delete;
using Application.Features.Ematerials.Commands.Update;
using Application.Features.Ematerials.Queries.GetById;
using Application.Features.Ematerials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEmaterialCommand createEmaterialCommand)
    {
        CreatedEmaterialResponse response = await Mediator.Send(createEmaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEmaterialCommand updateEmaterialCommand)
    {
        UpdatedEmaterialResponse response = await Mediator.Send(updateEmaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedEmaterialResponse response = await Mediator.Send(new DeleteEmaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdEmaterialResponse response = await Mediator.Send(new GetByIdEmaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEmaterialQuery getListEmaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEmaterialListItemDto> response = await Mediator.Send(getListEmaterialQuery);
        return Ok(response);
    }
}