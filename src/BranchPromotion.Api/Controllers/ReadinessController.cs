using BranchPromotion.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BranchPromotion.Api.Controllers;

[Route("readiness")]
public class ReadinessController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    
    /// <summary>
    /// Ctor
    /// </summary>
    public ReadinessController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <remarks>Method description</remarks>
    /// <returns>Model</returns>
    [HttpGet]
    public IActionResult Get()
    {
        _ = _dbContext.BranchPromotionVariant.FirstOrDefault();
        
        return Ok(new
        {
            ServerTime = DateTime.Now
        });
    }
}
