using System.ComponentModel.DataAnnotations;

namespace Group5_API_Project.DTO
{
    public class ProductResponseDTO
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public CategoryDTO Categories { get; set; } = new CategoryDTO();
    }
}
