using System.ComponentModel.DataAnnotations;

namespace Group5_API_Project.DTO
{
    public class AccountDTO
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
