using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; } = decimal.Zero;

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
