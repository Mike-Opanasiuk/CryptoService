using Application.Features.AccountFeatures.Commands;
using Application.Features.AccountFeatures.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly IMediator mediator;

    public AccountController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> RegisterAsync([FromBody] RegisterUserCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> LoginAsync([FromBody] LoginUserCommand command)
    {
        return await mediator.Send(command);
    }
}
