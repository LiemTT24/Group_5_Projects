using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class Supplier
    {
        [Key]
        [Range(1, int.MaxValue)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Supplier name must be less than or equal 50 characters")]
        public string? SupplierName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The Description must be less than or equal 200 characters")]
        public string? Description { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }

        [Required]
        public DateTime? UpdatedDate { get; set; }

        public Product? Products { get; set; }
    }
}
