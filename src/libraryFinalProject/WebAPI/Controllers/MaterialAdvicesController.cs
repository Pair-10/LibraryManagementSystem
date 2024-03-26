using Application.Features.MaterialAdvices.Commands.Create;
using Application.Features.MaterialAdvices.Commands.Delete;
using Application.Features.MaterialAdvices.Commands.Update;
using Application.Features.MaterialAdvices.Queries.GetById;
using Application.Features.MaterialAdvices.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialAdvicesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialAdviceCommand createMaterialAdviceCommand)
    {
        CreatedMaterialAdviceResponse response = await Mediator.Send(createMaterialAdviceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialAdviceCommand updateMaterialAdviceCommand)
    {
        UpdatedMaterialAdviceResponse response = await Mediator.Send(updateMaterialAdviceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialAdviceResponse response = await Mediator.Send(new DeleteMaterialAdviceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialAdviceResponse response = await Mediator.Send(new GetByIdMaterialAdviceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaterialAdviceQuery getListMaterialAdviceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaterialAdviceListItemDto> response = await Mediator.Send(getListMaterialAdviceQuery);
        return Ok(response);
    }
}