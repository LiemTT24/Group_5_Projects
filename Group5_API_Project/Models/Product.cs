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
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } 

        [Required]
        public decimal UnitPrice { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public Category Categories { get; set; } = new Category();

        public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    }
}
