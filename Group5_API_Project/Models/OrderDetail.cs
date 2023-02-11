using System.ComponentModel.DataAnnotations;

namespace Group5_API_Project.Models
{
    public class OrderDetail
    {
        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Range(0, 100)]
        public byte Discount { get; set; }

        public Product? Product { get; set; }
        public Order? Order { get; set; }
    }
}
