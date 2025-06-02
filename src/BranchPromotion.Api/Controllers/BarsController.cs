using BranchPromotion.Api.Models.Bars;
using BranchPromotion.Application.Commands.Bars;
using BranchPromotion.Application.Queries.Bars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BranchPromotion.Api.Controllers;

[ApiController]
[Route("api/v1/bars")]
public class BarsController : ControllerBase
{
    private readonly ISender _sender;

    public BarsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<GetBarResponse> Get([FromRoute] int id)
    {
        var bar = await _sender.Send(new GetBarQuery { Id = id });

        return ToGetBarResponse(bar);
    }

    [HttpGet]
    public async Task<GetBarsResponse> Get([FromQuery] GetBarsRequest request)
    {
        var result = await _sender.Send(new GetBarsQuery
        {
            Page = request.Page,
            Size = request.Size
        });

        return new GetBarsResponse
        {
            TotalCount = result.TotalCount,
            Bars = result.Data.Select(ToGetBarResponse).ToList()
        };
    }

    [HttpPost]
    public async Task<PostBarResponse> Post([FromBody] CreateBarRequest request)
    {
        var result = await _sender.Send(new CreateBarCommand { Name = request.Name });

        return new PostBarResponse { Id = result.Id };
    }

    private GetBarResponse ToGetBarResponse(GetBarQueryResult result)
    {
        return new GetBarResponse
        {
            Id = result.Id,
            Name = result.Name
        };
    }
}
