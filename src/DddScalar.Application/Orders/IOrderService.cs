using DddScalar.Domain.Orders;

namespace DddScalar.Application.Orders;

public interface IOrderService
{
    Task<OrderResponse> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken = default);
    Task<OrderResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
