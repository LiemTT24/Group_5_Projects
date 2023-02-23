using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class RoleManager : IdentityRole<int>
    {
        [StringLength(100, ErrorMessage = "The description must be less than or equal 100 characters")]
        public string? Description { get; set; }
    }
}
