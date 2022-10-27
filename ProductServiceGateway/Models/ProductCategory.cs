using System.ComponentModel.DataAnnotations;

namespace ProductServiceGateway.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string?  CategoryIcon { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
