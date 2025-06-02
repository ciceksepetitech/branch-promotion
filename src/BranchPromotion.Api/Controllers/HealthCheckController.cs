using Cosmos.Monitoring;
using Microsoft.AspNetCore.Mvc;

namespace BranchPromotion.Api.Controllers;

/// <summary>
/// HealthCheckController
/// </summary>
[Route("healthcheck")]
public class HealthCheckController : ControllerBase
{
    private readonly HealthCheck _healthCheck;

    /// <summary>
    /// Ctor
    /// </summary>
    public HealthCheckController(HealthCheck healthCheck)
    {
        _healthCheck = healthCheck;
    }

    /// <summary>
    /// Get health check
    /// </summary>
    /// <returns>Build and docker image info object.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_healthCheck);
    }
}
