using Application.Features.Penalties.Commands.Create;
using Application.Features.Penalties.Commands.Delete;
using Application.Features.Penalties.Commands.Update;
using Application.Features.Penalties.Queries.GetById;
using Application.Features.Penalties.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Penalties.Queries.GetUserById;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PenaltiesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePenaltyCommand createPenaltyCommand)
    {
        CreatedPenaltyResponse response = await Mediator.Send(createPenaltyCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePenaltyCommand updatePenaltyCommand)
    {
        UpdatedPenaltyResponse response = await Mediator.Send(updatePenaltyCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedPenaltyResponse response = await Mediator.Send(new DeletePenaltyCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdPenaltyResponse response = await Mediator.Send(new GetByIdPenaltyQuery { Id = id });
        return Ok(response);
    }
    //[HttpGet("byUserId/{userid}")] // 
    //public async Task<IActionResult> GetByUserId([FromRoute] Guid userid)
    //{
    //    GetByUserIdPenaltyResponse response = await Mediator.Send(new GetByUserIdPenaltyQuery { UserId = userid });
    //    return Ok(response);
    //}
    [HttpGet("byUserId/{userid}")] // 
    public async Task<IActionResult> GetAllPenalties()
    {
        var response = await Mediator.Send(new GetAllPenaltiesQuery());
        return Ok(response);
    }







    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPenaltyQuery getListPenaltyQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPenaltyListItemDto> response = await Mediator.Send(getListPenaltyQuery);
        return Ok(response);
    }
}