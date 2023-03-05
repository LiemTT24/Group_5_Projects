using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class OrderChecking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderCheckingID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The length of OrderCheckingName must be less than or equal 50 characters")]
        public string OrderCheckingName { get; set; } = string.Empty;
    }
}
