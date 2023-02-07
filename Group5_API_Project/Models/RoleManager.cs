using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class RoleManager
    {
        [Key]
        [Range(1, int.MaxValue)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleManagerID { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The RoleManager name must be less than or equal 20 characters")]
        public string? RoleManagerName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The description must be less than or equal 100 characters")]
        public string? Description { get; set; }
    }
}
