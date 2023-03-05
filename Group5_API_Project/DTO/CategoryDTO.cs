using System.ComponentModel.DataAnnotations;

namespace Group5_API_Project.DTO
{
    public class CategoryDTO
    {
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;
    }
}
