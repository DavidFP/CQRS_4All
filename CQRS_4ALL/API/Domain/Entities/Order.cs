using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Entities
{
    [Table("Orders")]
    public class Order : BaseEntity
    {
        [Required]
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public virtual ICollection<Product>? Products { get; set; }
    }
}