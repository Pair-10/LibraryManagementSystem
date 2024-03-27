using Application.Features.UserAddresses.Commands.Create;
using Application.Features.UserAddresses.Commands.Delete;
using Application.Features.UserAddresses.Commands.Update;
using Application.Features.UserAddresses.Queries.GetById;
using Application.Features.UserAddresses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAddressesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserAddressCommand createUserAddressCommand)
    {
        CreatedUserAddressResponse response = await Mediator.Send(createUserAddressCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserAddressCommand updateUserAddressCommand)
    {
        UpdatedUserAddressResponse response = await Mediator.Send(updateUserAddressCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserAddressResponse response = await Mediator.Send(new DeleteUserAddressCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserAddressResponse response = await Mediator.Send(new GetByIdUserAddressQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserAddressQuery getListUserAddressQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserAddressListItemDto> response = await Mediator.Send(getListUserAddressQuery);
        return Ok(response);
    }
}