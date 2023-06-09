﻿using System;
namespace API.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; }
        public string? Name { get; }
        public string? Description { get; }
        public int Quantity { get; }
        public decimal Price { get; } = decimal.Zero;

        public ProductDto(int id, string? name, string? description, int quantity, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
        }
    }
}

