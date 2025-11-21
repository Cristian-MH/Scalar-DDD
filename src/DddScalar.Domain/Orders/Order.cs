namespace DddScalar.Domain.Orders;

public sealed class Order
{
    public Guid Id { get; private set; }
    public string CustomerName { get; private set; } = null!;
    public DateTime CreatedAtUtc { get; private set; }

    private Order() { }

    private Order(Guid id, string customerName)
    {
        Id = id;
        CustomerName = customerName;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public static Order Create(string customerName)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new DomainException("Customer name is required.");

        return new Order(Guid.NewGuid(), customerName.Trim());
    }
}
