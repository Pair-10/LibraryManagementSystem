using Application.Features.MaterialLocations.Commands.Create;
using Application.Features.MaterialLocations.Commands.Delete;
using Application.Features.MaterialLocations.Commands.Update;
using Application.Features.MaterialLocations.Queries.GetById;
using Application.Features.MaterialLocations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialLocationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialLocationCommand createMaterialLocationCommand)
    {
        CreatedMaterialLocationResponse response = await Mediator.Send(createMaterialLocationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialLocationCommand updateMaterialLocationCommand)
    {
        UpdatedMaterialLocationResponse response = await Mediator.Send(updateMaterialLocationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialLocationResponse response = await Mediator.Send(new DeleteMaterialLocationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialLocationResponse response = await Mediator.Send(new GetByIdMaterialLocationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaterialLocationQuery getListMaterialLocationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaterialLocationListItemDto> response = await Mediator.Send(getListMaterialLocationQuery);
        return Ok(response);
    }
}