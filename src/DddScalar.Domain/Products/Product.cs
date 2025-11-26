using System;
using DddScalar.Domain;

namespace DddScalar.Domain.Products
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(Guid id, string name, decimal price)
        {
            if (id == Guid.Empty) throw new DomainException("El Id del producto no puede ser vacío.");
            if (string.IsNullOrWhiteSpace(name)) throw new DomainException("El nombre del producto es obligatorio.");
            if (price < 0) throw new DomainException("El precio del producto no puede ser negativo.");

            Id = id;
            Name = name.Trim();
            Price = price;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new DomainException("El nombre del producto es obligatorio.");
            Name = name.Trim();
        }

        public void UpdatePrice(decimal price)
        {
            if (price < 0) throw new DomainException("El precio del producto no puede ser negativo.");
            Price = price;
        }
    }
}
