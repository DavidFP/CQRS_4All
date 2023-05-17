using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key,Required]
        public int Id { get; set; }
        public int ProductId { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Address { get; set; }     
        public DateTime CreatedAt { get; set; }     
        public DateTime UpdatedAt { get; set;}

        public virtual Product? Product { get; set; }
    }
}