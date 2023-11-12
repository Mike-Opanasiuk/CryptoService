
using Core.Entities.Abstract;

namespace Core.Entities;

public class OrderTypeEntity : BaseEntity, IEntity
{
    public string Name { get; set; }
}
