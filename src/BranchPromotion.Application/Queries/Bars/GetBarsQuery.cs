using BranchPromotion.Domain.Repositories.Bars;
using Mapster;
using MediatR;

namespace BranchPromotion.Application.Queries.Bars;

public record GetBarsQuery : IRequest<GetBarsQueryResult>
{
    public int Page { get; init; }
    public int Size { get; init; }
}

public record GetBarsQueryResult
{
    public int TotalCount { get; init; }
    public List<GetBarQueryResult> Data { get; init; }
}

public class GetBarsQueryHandler : IRequestHandler<GetBarsQuery, GetBarsQueryResult>
{
    private readonly IBarRepository _barRepository;

    public GetBarsQueryHandler(IBarRepository barRepository)
    {
        _barRepository = barRepository;
    }

    public async Task<GetBarsQueryResult> Handle(GetBarsQuery request, CancellationToken cancellationToken)
    {
        var (totalCount, bars) = await _barRepository.GetBars();
        var queryResults = bars.Adapt<List<GetBarQueryResult>>();
        return new GetBarsQueryResult { TotalCount = totalCount, Data = queryResults };
    }
}
