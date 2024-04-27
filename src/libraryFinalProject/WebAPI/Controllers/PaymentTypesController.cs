using Application.Features.PaymentTypes.Commands.Create;
using Application.Features.PaymentTypes.Commands.Delete;
using Application.Features.PaymentTypes.Commands.Update;
using Application.Features.PaymentTypes.Queries.GetById;
using Application.Features.PaymentTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePaymentTypeCommand createPaymentTypeCommand)
    {
        CreatedPaymentTypeResponse response = await Mediator.Send(createPaymentTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePaymentTypeCommand updatePaymentTypeCommand)
    {
        UpdatedPaymentTypeResponse response = await Mediator.Send(updatePaymentTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedPaymentTypeResponse response = await Mediator.Send(new DeletePaymentTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdPaymentTypeResponse response = await Mediator.Send(new GetByIdPaymentTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPaymentTypeQuery getListPaymentTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPaymentTypeListItemDto> response = await Mediator.Send(getListPaymentTypeQuery);
        return Ok(response);
    }
}