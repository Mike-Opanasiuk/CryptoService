
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

public class CurrencyEntity : BaseEntity, IEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public UserEntity User { get; set; }
}
