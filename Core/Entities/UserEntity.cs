﻿using Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class UserEntity : IdentityUser<Guid>, IEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public IEnumerable<CurrencyEntity> Currencies { get; set; }
    public IEnumerable<OrderEntity> Orders { get; set; }
}