using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.App.Commands.Register;

namespace UserManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand cmd)
    {
        return Ok(await _mediator.Send(cmd));
    }
}
