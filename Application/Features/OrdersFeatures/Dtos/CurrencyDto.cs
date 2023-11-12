using Application.Features.AccountFeatures.Dtos;

namespace Application.Features.OrdersFeatures.Dtos;

public class CurrencyDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public UserDto User { get; set; }
}
