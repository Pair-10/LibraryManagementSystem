using Application.Features.Invoices.Commands.Create;
using Application.Features.Invoices.Commands.Delete;
using Application.Features.Invoices.Commands.Update;
using Application.Features.Invoices.Queries.GetById;
using Application.Features.Invoices.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateInvoiceCommand createInvoiceCommand)
    {
        CreatedInvoiceResponse response = await Mediator.Send(createInvoiceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateInvoiceCommand updateInvoiceCommand)
    {
        UpdatedInvoiceResponse response = await Mediator.Send(updateInvoiceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedInvoiceResponse response = await Mediator.Send(new DeleteInvoiceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdInvoiceResponse response = await Mediator.Send(new GetByIdInvoiceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInvoiceQuery getListInvoiceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListInvoiceListItemDto> response = await Mediator.Send(getListInvoiceQuery);
        return Ok(response);
    }
}