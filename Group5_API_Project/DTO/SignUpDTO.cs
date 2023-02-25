using System.ComponentModel.DataAnnotations;

namespace Group5_API_Project.DTO
{
    public class SignUpDTO
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(6), MaxLength(20)]
        [StringLength(20, ErrorMessage = "The password must be less than 20 characters")]
        public string? Password { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
