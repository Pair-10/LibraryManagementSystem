using Application.Features.MaterialTranslators.Commands.Create;
using Application.Features.MaterialTranslators.Commands.Delete;
using Application.Features.MaterialTranslators.Commands.Update;
using Application.Features.MaterialTranslators.Queries.GetById;
using Application.Features.MaterialTranslators.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialTranslatorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialTranslatorCommand createMaterialTranslatorCommand)
    {
        CreatedMaterialTranslatorResponse response = await Mediator.Send(createMaterialTranslatorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialTranslatorCommand updateMaterialTranslatorCommand)
    {
        UpdatedMaterialTranslatorResponse response = await Mediator.Send(updateMaterialTranslatorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialTranslatorResponse response = await Mediator.Send(new DeleteMaterialTranslatorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialTranslatorResponse response = await Mediator.Send(new GetByIdMaterialTranslatorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaterialTranslatorQuery getListMaterialTranslatorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaterialTranslatorListItemDto> response = await Mediator.Send(getListMaterialTranslatorQuery);
        return Ok(response);
    }
}