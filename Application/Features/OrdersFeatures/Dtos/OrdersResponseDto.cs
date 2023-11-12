namespace Application.Features.OrdersFeatures.Dtos;

public class OrdersResponseDto
{
    public ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();
    public int TotalPages { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
}
