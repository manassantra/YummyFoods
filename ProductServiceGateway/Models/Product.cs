using System.ComponentModel.DataAnnotations;

namespace ProductServiceGateway.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }

        [Required]
        public double? Price { get; set; } 
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
