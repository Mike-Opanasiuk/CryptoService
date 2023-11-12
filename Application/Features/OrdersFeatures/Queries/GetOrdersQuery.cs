

using Application.Features.OrdersFeatures.Dtos;
using AutoMapper;
using MediatR;
using Infrastructure.UnitOfWork.Abstract;
using static Shared.AppConstant;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.OrdersFeatures.Queries;

public record GetOrdersQuery : IRequest<OrdersResponseDto>
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public string SearchString { get; set; }
    public string OrderBy { get; set; }
    public string Order { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
}

public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, OrdersResponseDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetOrdersHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public Task<OrdersResponseDto> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = unitOfWork.Orders
            .Get()
            .Include(t => t.User)
            .Include(t => t.Currency)
            .Include(t => t.OrderType)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchString))
        {
            orders = orders.Where(t => t.Currency.Name.ToLower().Contains(request.SearchString.ToLower()));
        }

        if (request.MinPrice != default)
        {
            orders = orders.Where(t => t.Currency.Price * t.Quantity >= request.MinPrice);
        }

        if (request.MaxPrice != default)
        {
            orders = orders.Where(t => t.Currency.Price * t.Quantity <= request.MaxPrice);
        }

        if (!orders.Any())
        {
            return Task.FromResult(new OrdersResponseDto());
        }

        orders = SortOrders(orders, request.OrderBy, request.Order);

        var minPrice = orders.Min(t => t.Currency.Price * t.Quantity);
        var maxPrice = orders.Max(t => t.Currency.Price * t.Quantity);

        orders = Paginate(
            orders,
            request.PerPage == default ? General.DefaultPerPage : request.PerPage,
            request.Page == default ? General.DefaultPage : request.Page,
            out int totalPages);

        return Task.FromResult(new OrdersResponseDto()
        {
            TotalPages = totalPages,
            Orders = mapper.Map<ICollection<OrderDto>>(orders),
            MaxPrice = maxPrice,
            MinPrice = minPrice
        });
    }

    public static IQueryable<T> Paginate<T>(IQueryable<T> items, int perPage, int page, out int totalPages)
    {
        var count = items.Count();

        items = items.Skip((page - 1) * perPage).Take(perPage);

        if (count <= perPage && count != 0)
        {
            totalPages = 1;
            return items;
        }

        totalPages = count / perPage;

        if (totalPages % perPage > 0)
        {
            ++totalPages;
        }
        return items;
    }

    private static IQueryable<OrderEntity> SortOrders(IQueryable<OrderEntity> orders, string orderBy, string order)
    {
        switch (orderBy)
        {
            case SortOrder.By.Name:
                switch (order)
                {
                    case SortOrder.Asc:
                        return orders.OrderBy(p => p.Currency.Name);
                    case SortOrder.Desc:
                        return orders.OrderByDescending(p => p.Currency.Name);
                }
                break;
            case SortOrder.By.Date:
                switch (order)
                {
                    case SortOrder.Asc:
                        return orders.OrderBy(p => p.CreatedAt);
                    case SortOrder.Desc:
                        return orders.OrderByDescending(p => p.CreatedAt);
                }
                break;
            case SortOrder.By.Price:
                switch (order)
                {
                    case SortOrder.Asc:
                        return orders.OrderBy(p => p.Currency.Price * p.Quantity);
                    case SortOrder.Desc:
                        return orders.OrderByDescending(p => p.Currency.Price * p.Quantity);
                }
                break;
        }
        return orders;
    }
}
