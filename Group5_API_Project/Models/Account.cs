using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Your email must be less than or equal 50 characters")]
        [EmailAddress(ErrorMessage = "The email format did not supported.")]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Your full name must be less than or equal 50 characters")]
        public string? FullName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Your Phone number must be include 10 characters")]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your Address must be less than or equal 100 characters")]
        public string? Address { get; set; }


        //[ForeignKey(nameof(RoleManagers))]
        //public int Id { get; set; }
        //public RoleManager? RoleManagers { get; set; }
    }
}
