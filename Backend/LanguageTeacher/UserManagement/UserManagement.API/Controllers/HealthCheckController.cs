using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;
        private readonly IMediator _mediator;

        public HealthCheckController(ILogger<HealthCheckController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "HealthCheck")]
        public async Task<ActionResult<string>> Get()
        {
            return Ok("test");
        }
    }
}
