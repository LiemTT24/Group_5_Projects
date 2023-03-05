using System.ComponentModel.DataAnnotations;

namespace Group5_API_Project.DTO
{
    public class OrderCheckingDTO
    {
        [Required]
        public int OrderCheckingID { get; set; }
        [Required]
        public string OrderCheckingName { get; set; } = string.Empty; 
    }
}
