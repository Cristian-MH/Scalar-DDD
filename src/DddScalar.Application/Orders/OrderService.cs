using DddScalar.Domain;
using DddScalar.Domain.Orders;

namespace DddScalar.Application.Orders;

public sealed class OrderService : IOrderService
{
    private readonly IOrderRepository _orders;

    public OrderService(IOrderRepository orders)
    {
        _orders = orders;
    }

    public async Task<OrderResponse> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var order = Order.Create(request.CustomerName);
            await _orders.AddAsync(order, cancellationToken);

            return new OrderResponse(order.Id, order.CustomerName, order.CreatedAtUtc);
        }
        catch (DomainException ex)
        {
            throw new ApplicationException(ex.Message, ex);
        }
    }

    public async Task<OrderResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await _orders.GetByIdAsync(id, cancellationToken);
        if (order is null) return null;

        return new OrderResponse(order.Id, order.CustomerName, order.CreatedAtUtc);
    }
}
