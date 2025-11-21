namespace DddScalar.Application.Orders;

public sealed record OrderResponse(Guid Id, string CustomerName, DateTime CreatedAtUtc);
