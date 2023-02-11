using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Product name must be less than or equal 100 characters")]
        public string? ProductName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } 

        [Required]
        public decimal UnitPrice { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int SupplierID { get; set; }
        public Supplier? Suppliers { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public Category? Categories { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
