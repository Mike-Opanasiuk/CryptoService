using Core.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Infrastructure.Repository.Abstract;

namespace Infrastructure.UnitOfWork.Abstract;

public interface IUnitOfWork
{
    IRepository<OrderEntity> Orders { get; }
    IRepository<OrderTypeEntity> OrderTypes { get; }
    IRepository<CurrencyEntity> Currencies { get; }

    Task<int> SaveChangesAsync();
}
