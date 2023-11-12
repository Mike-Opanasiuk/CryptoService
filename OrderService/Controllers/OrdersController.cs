using Application.Features.OrdersFeatures.Dtos;
using Application.Features.OrdersFeatures.Queries;
using AutoMapper;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public OrdersController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<OrdersResponseDto>> GetOrdersAsync([FromQuery] GetOrdersQuery request)
    {
        return await mediator.Send(request);
    }
}
