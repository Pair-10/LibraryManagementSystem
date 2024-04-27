using Application.Features.Magazines.Commands.Create;
using Application.Features.Magazines.Commands.Delete;
using Application.Features.Magazines.Commands.Update;
using Application.Features.Magazines.Queries.GetById;
using Application.Features.Magazines.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MagazinesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMagazineCommand createMagazineCommand)
    {
        CreatedMagazineResponse response = await Mediator.Send(createMagazineCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMagazineCommand updateMagazineCommand)
    {
        UpdatedMagazineResponse response = await Mediator.Send(updateMagazineCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMagazineResponse response = await Mediator.Send(new DeleteMagazineCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMagazineResponse response = await Mediator.Send(new GetByIdMagazineQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMagazineQuery getListMagazineQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMagazineListItemDto> response = await Mediator.Send(getListMagazineQuery);
        return Ok(response);
    }
}