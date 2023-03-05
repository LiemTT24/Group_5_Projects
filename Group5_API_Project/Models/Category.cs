using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Category name must be less than or equal 100 characters")]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        [StringLength(200, ErrorMessage = "The Description must be less than or equal 200 characters")]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
