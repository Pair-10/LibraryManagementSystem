using Application.Features.OrderEMaterials.Commands.Create;
using Application.Features.OrderEMaterials.Commands.Delete;
using Application.Features.OrderEMaterials.Commands.Update;
using Application.Features.OrderEMaterials.Queries.GetById;
using Application.Features.OrderEMaterials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderEMaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrderEMaterialCommand createOrderEMaterialCommand)
    {
        CreatedOrderEMaterialResponse response = await Mediator.Send(createOrderEMaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderEMaterialCommand updateOrderEMaterialCommand)
    {
        UpdatedOrderEMaterialResponse response = await Mediator.Send(updateOrderEMaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedOrderEMaterialResponse response = await Mediator.Send(new DeleteOrderEMaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdOrderEMaterialResponse response = await Mediator.Send(new GetByIdOrderEMaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrderEMaterialQuery getListOrderEMaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOrderEMaterialListItemDto> response = await Mediator.Send(getListOrderEMaterialQuery);
        return Ok(response);
    }
}