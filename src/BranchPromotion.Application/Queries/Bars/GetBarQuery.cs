using Cosmos.Caching;
using Cosmos.Status;
using BranchPromotion.Domain.Repositories.Bars;
using Mapster;
using MediatR;

namespace BranchPromotion.Application.Queries.Bars;

public record GetBarQuery : IRequest<GetBarQueryResult>
{
    public int Id { get; init; }
}

public class GetBarQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class GetBarQueryHandler : IRequestHandler<GetBarQuery, GetBarQueryResult>
{
    private readonly IBarRepository _barRepository;
    private readonly ICacheProvider _cacheProvider;

    public GetBarQueryHandler(IBarRepository barRepository,
        ICacheProvider cacheProvider)
    {
        _barRepository = barRepository;
        _cacheProvider = cacheProvider;
    }

    public async Task<GetBarQueryResult> Handle(GetBarQuery request, CancellationToken cancellationToken)
    {
        var bar = await _cacheProvider.GetAsync($"bar.{request.Id}", CacheTime.OneHour,
            async () => await _barRepository.Get(request.Id), cancellationToken);

        return bar == null ? throw new StatusException(StatusCode.NotFound, "bar.not.found") : bar.Adapt<GetBarQueryResult>();
    }
}
