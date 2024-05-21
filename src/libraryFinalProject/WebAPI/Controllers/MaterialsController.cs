using Application.Features.Materials.Commands.Create;
using Application.Features.Materials.Commands.Delete;
using Application.Features.Materials.Commands.Update;
using Application.Features.Materials.Queries.GetById;
using Application.Features.Materials.Queries.GetDynamic;
using Application.Features.Materials.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialCommand createMaterialCommand)
    {
        CreatedMaterialResponse response = await Mediator.Send(createMaterialCommand);

        return Created(uri: "", response);
    }

    //[HttpPut]
    //public async Task<IActionResult> Update([FromBody] UpdateMaterialCommand updateMaterialCommand)
    //{
    //    UpdatedMaterialResponse response = await Mediator.Send(updateMaterialCommand);

    //    return Ok(response);
    //}

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMaterialCommand updateMaterialCommand)
    {
        if (id != updateMaterialCommand.Id)
        {
            return BadRequest("ID mismatch between route and request body.");
        }

        UpdatedMaterialResponse response = await Mediator.Send(updateMaterialCommand);

        return Ok(response);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialResponse response = await Mediator.Send(new DeleteMaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialResponse response = await Mediator.Send(new GetByIdMaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaterialQuery getListMaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaterialListItemDto> response = await Mediator.Send(getListMaterialQuery);
        return Ok(response);
    }
    [HttpPost("dynamic")]
    public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamic)
    {
        GetDynamicMaterialQuery query = new() { Dynamic = dynamic, PageRequest = pageRequest };
        var response = await Mediator.Send(query);
        return Ok(response);
    }
}