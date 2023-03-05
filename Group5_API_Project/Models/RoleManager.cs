using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class RoleManager : IdentityRole<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleManagerID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Role name must be less than or equal 100 characters")]
        public string RoleManagerName { get; set; } = string.Empty;
    }
}
