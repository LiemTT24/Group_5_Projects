using System.ComponentModel.DataAnnotations;

namespace Group5_API_Project.DTO
{
    public class OrderDetailDTO
    {
        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        [Range(0, 100)]
        public Int16 Discount { get; set; }
    }
}
