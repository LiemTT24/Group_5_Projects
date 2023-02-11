using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class Order
    {
        [Key]
        [Range(1, int.MaxValue)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The description must be less than or equal 200 characters")]
        public string? Description { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Address must be less than or equal 100 characters")]
        public string? Address { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; } //input type =>> hidden

        public virtual ICollection<Product>? Products { get; set; }

        [ForeignKey(nameof(Account))]
        public int AccountID { get; set; }
        public Account? Accounts { get; set; }

        public OrderChecking OrderStatus { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
    
    public enum OrderChecking
    {
        Confirmed = 1, Delivering = 2, Received = 3, Cancel = 4
    }
}
