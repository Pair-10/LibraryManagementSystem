using Application.Features.MaterialAuthors.Commands.Create;
using Application.Features.MaterialAuthors.Commands.Delete;
using Application.Features.MaterialAuthors.Commands.Update;
using Application.Features.MaterialAuthors.Queries.GetById;
using Application.Features.MaterialAuthors.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialAuthorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialAuthorCommand createMaterialAuthorCommand)
    {
        CreatedMaterialAuthorResponse response = await Mediator.Send(createMaterialAuthorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialAuthorCommand updateMaterialAuthorCommand)
    {
        UpdatedMaterialAuthorResponse response = await Mediator.Send(updateMaterialAuthorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialAuthorResponse response = await Mediator.Send(new DeleteMaterialAuthorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialAuthorResponse response = await Mediator.Send(new GetByIdMaterialAuthorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaterialAuthorQuery getListMaterialAuthorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaterialAuthorListItemDto> response = await Mediator.Send(getListMaterialAuthorQuery);
        return Ok(response);
    }
}