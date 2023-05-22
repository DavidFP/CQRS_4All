using System;
using API.Domain.Entities;

namespace API.Application.Dtos
{
    public class OrderDto
    {
        public OrderDto(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public int Id { get; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}

