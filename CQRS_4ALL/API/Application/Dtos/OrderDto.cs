using System;
using API.Domain.Entities;

namespace API.Application.Dtos
{
	public class OrderDto
	{
        public int Id { get; }
        public string? Name  { get; }
        public string? Description { get;}
        public int Quantity { get; }
        public decimal Price { get; }
        public IList<OrderDto>? Orders { get; }

        public OrderDto(int id, string? name, string? description, int quantity, decimal price, IList<OrderDto>? orders)
        {
            Id = id;
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
            Orders = orders;
        }
    }
}

