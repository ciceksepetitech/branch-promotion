using Refit;
using BranchPromotion.Domain.Services.Bazs.Response;
using BranchPromotion.Domain.Services.Bazs.Request;

namespace BranchPromotion.Domain.Services.Bazs;

public interface IBazService
{
    [Get("/bazs/{id}")]
    Task<BazServiceResponse> Get(int id);

    [Post("/bazs")]
    Task<BazServiceResponse> Create([Body] CreateBazServiceRequest request);
}
