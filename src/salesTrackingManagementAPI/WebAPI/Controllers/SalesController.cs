using Application.Features.Sales.Commands.Create;
using Application.Features.Sales.Commands.Delete;
using Application.Features.Sales.Commands.Update;
using Application.Features.Sales.Queries.GetById;
using Application.Features.Sales.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSaleCommand createSaleCommand)
    {
        CreatedSaleResponse response = await Mediator.Send(createSaleCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSaleCommand updateSaleCommand)
    {
        UpdatedSaleResponse response = await Mediator.Send(updateSaleCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSaleResponse response = await Mediator.Send(new DeleteSaleCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSaleResponse response = await Mediator.Send(new GetByIdSaleQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSaleQuery getListSaleQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSaleListItemDto> response = await Mediator.Send(getListSaleQuery);
        return Ok(response);
    }
}