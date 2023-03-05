using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The CustomerName must be less than or equal 100 characters")]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The ShipperName must be less than or equal 100 characters")]
        public string ShipperName { get; set; } = string.Empty;

        [Required]
        [StringLength(10, ErrorMessage = "Your Phone number must be include 10 characters")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now.Date;

        [Required]
        public DateTime StartDeliveryDate { get; set; } = DateTime.Now.Date;

        [Required]
        public DateTime EndDeliveryDate { get; set; } = DateTime.Now.Date;

        [Required]
        [StringLength(100, ErrorMessage = "The Address must be less than or equal 100 characters")]
        public string Address { get; set; } = string.Empty;

        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; } //input type =>> hidden

        public ICollection<Product> Products { get; set; } = new List<Product>();

        [ForeignKey(nameof(OrderChecking))]
        public int OrderCheckingID { get; set; }
        public ICollection<OrderChecking> OrderCheck { get; set; } = new HashSet<OrderChecking>();

        public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    }
}
