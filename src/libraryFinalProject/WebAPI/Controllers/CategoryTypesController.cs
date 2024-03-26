using Application.Features.CategoryTypes.Commands.Create;
using Application.Features.CategoryTypes.Commands.Delete;
using Application.Features.CategoryTypes.Commands.Update;
using Application.Features.CategoryTypes.Queries.GetById;
using Application.Features.CategoryTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryTypeCommand createCategoryTypeCommand)
    {
        CreatedCategoryTypeResponse response = await Mediator.Send(createCategoryTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryTypeCommand updateCategoryTypeCommand)
    {
        UpdatedCategoryTypeResponse response = await Mediator.Send(updateCategoryTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCategoryTypeResponse response = await Mediator.Send(new DeleteCategoryTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCategoryTypeResponse response = await Mediator.Send(new GetByIdCategoryTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryTypeQuery getListCategoryTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCategoryTypeListItemDto> response = await Mediator.Send(getListCategoryTypeQuery);
        return Ok(response);
    }
}