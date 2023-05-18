using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key,Required]
        public int Id { get; set; }
        [Required]
        public string? Name  { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; } 
        public decimal Price { get; set; } = decimal.Zero;

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
