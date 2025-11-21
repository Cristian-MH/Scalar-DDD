using System.Collections.Concurrent;
using DddScalar.Domain.Orders;

namespace DddScalar.Infrastructure.Orders;

public sealed class InMemoryOrderRepository : IOrderRepository
{
    private static readonly ConcurrentDictionary<Guid, Order> Store = new();

    public Task AddAsync(Order order, CancellationToken cancellationToken = default)
    {
        Store[order.Id] = order;
        return Task.CompletedTask;
    }

    public Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Store.TryGetValue(id, out var order);
        return Task.FromResult(order);
    }
}
