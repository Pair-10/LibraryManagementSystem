using Application.Features.MaterialPublishers.Commands.Create;
using Application.Features.MaterialPublishers.Commands.Delete;
using Application.Features.MaterialPublishers.Commands.Update;
using Application.Features.MaterialPublishers.Queries.GetById;
using Application.Features.MaterialPublishers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialPublishersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialPublisherCommand createMaterialPublisherCommand)
    {
        CreatedMaterialPublisherResponse response = await Mediator.Send(createMaterialPublisherCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialPublisherCommand updateMaterialPublisherCommand)
    {
        UpdatedMaterialPublisherResponse response = await Mediator.Send(updateMaterialPublisherCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialPublisherResponse response = await Mediator.Send(new DeleteMaterialPublisherCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialPublisherResponse response = await Mediator.Send(new GetByIdMaterialPublisherQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaterialPublisherQuery getListMaterialPublisherQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaterialPublisherListItemDto> response = await Mediator.Send(getListMaterialPublisherQuery);
        return Ok(response);
    }
}