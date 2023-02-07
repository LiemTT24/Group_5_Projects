using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_API_Project.Models
{
    public class Order
    {
        [Key]
        [Range(1, int.MaxValue)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Order name must be less than or equal 50 characters")]
        public string? OrderName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The description must be less than or equal 200 characters")]
        public string? Description { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Address must be less than or equal 100 characters")]
        public string? Address { get; set; }

        [ForeignKey(nameof(Products))]
        public int ProductID { get; set; } //input type =>> hidden

        public virtual ICollection<Product>? Products { get; set; }

        [ForeignKey(nameof(Accounts))]
        public int AccountID { get; set; }
        public Account? Accounts { get; set; }

        [ForeignKey(nameof(RoleManagers))]
        public string? RoleManagerID { get; set; }
        public RoleManager? RoleManagers { get; set; }

        public string? OrderStatus { get; set; }
    }
}
