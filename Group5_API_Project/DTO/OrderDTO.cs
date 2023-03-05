using Group5_API_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Group5_API_Project.DTO
{
    public class OrderDTO
    {
        [Required]
        public int OrderID { get; set; }
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        [Required] 
        public string ShipperName { get; set; } = string.Empty;

        [Required] 
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now.Date;
        [Required]
        public DateTime StartDeliveryDate { get; set; } = DateTime.Now.Date;
        [Required]
        public DateTime EndDeliveryDate { get; set; } = DateTime.Now.Date;

        [Required] 
        public string Address { get; set; } = string.Empty;
        [Required]
        public OrderCheckingDTO OrderStatus { get; set; } = new OrderCheckingDTO();
        [Required]
        public ProductDTO Products { get; set; } = new ProductDTO();
    }
}
