using Application.Features.EmaterialInvoices.Commands.Create;
using Application.Features.EmaterialInvoices.Commands.Delete;
using Application.Features.EmaterialInvoices.Commands.Update;
using Application.Features.EmaterialInvoices.Queries.GetById;
using Application.Features.EmaterialInvoices.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmaterialInvoicesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEmaterialInvoiceCommand createEmaterialInvoiceCommand)
    {
        CreatedEmaterialInvoiceResponse response = await Mediator.Send(createEmaterialInvoiceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEmaterialInvoiceCommand updateEmaterialInvoiceCommand)
    {
        UpdatedEmaterialInvoiceResponse response = await Mediator.Send(updateEmaterialInvoiceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedEmaterialInvoiceResponse response = await Mediator.Send(new DeleteEmaterialInvoiceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdEmaterialInvoiceResponse response = await Mediator.Send(new GetByIdEmaterialInvoiceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEmaterialInvoiceQuery getListEmaterialInvoiceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEmaterialInvoiceListItemDto> response = await Mediator.Send(getListEmaterialInvoiceQuery);
        return Ok(response);
    }
}