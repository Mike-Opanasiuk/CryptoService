
using Core.Entities.Abstract;

namespace Core.Entities;

public class OrderEntity : BaseEntity, IEntity
{
    public OrderTypeEntity OrderType { get; set; }
    public CurrencyEntity Currency { get; set; }
    public decimal Quantity { get; set; }
    public UserEntity User { get; set; }
}
