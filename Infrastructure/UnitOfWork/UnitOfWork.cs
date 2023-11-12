using Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Infrastructure.Repository.Abstract;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork.Abstract;
using Core.Entities;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext context;

    public UnitOfWork(ApplicationDbContext context)
    {
        this.context = context;

        Orders = new Repository<OrderEntity>(context);
        OrderTypes = new Repository<OrderTypeEntity>(context);
        Currencies = new Repository<CurrencyEntity>(context);
    }

    public IRepository<OrderEntity> Orders { get; }

    public IRepository<OrderTypeEntity> OrderTypes { get; }

    public IRepository<CurrencyEntity> Currencies { get; }

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}
