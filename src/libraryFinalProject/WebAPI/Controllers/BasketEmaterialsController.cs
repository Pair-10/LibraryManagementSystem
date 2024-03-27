using Application.Features.BasketEmaterials.Commands.Create;
using Application.Features.BasketEmaterials.Commands.Delete;
using Application.Features.BasketEmaterials.Commands.Update;
using Application.Features.BasketEmaterials.Queries.GetById;
using Application.Features.BasketEmaterials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketEmaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBasketEmaterialCommand createBasketEmaterialCommand)
    {
        CreatedBasketEmaterialResponse response = await Mediator.Send(createBasketEmaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBasketEmaterialCommand updateBasketEmaterialCommand)
    {
        UpdatedBasketEmaterialResponse response = await Mediator.Send(updateBasketEmaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBasketEmaterialResponse response = await Mediator.Send(new DeleteBasketEmaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBasketEmaterialResponse response = await Mediator.Send(new GetByIdBasketEmaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBasketEmaterialQuery getListBasketEmaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBasketEmaterialListItemDto> response = await Mediator.Send(getListBasketEmaterialQuery);
        return Ok(response);
    }
}