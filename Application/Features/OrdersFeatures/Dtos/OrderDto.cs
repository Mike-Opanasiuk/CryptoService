
using Application.Features.AccountFeatures.Dtos;
using Core.Entities;

namespace Application.Features.OrdersFeatures.Dtos;

public class OrderDto
{
    public Guid Id { get; set; }

    public OrderTypeDto OrderType { get; set; }
    public CurrencyDto Currency { get; set; }
    public decimal Quantity { get; set; }
    public UserDto User { get; set; }
}
