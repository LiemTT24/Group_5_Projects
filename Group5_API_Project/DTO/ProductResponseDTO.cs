using System.ComponentModel.DataAnnotations;

namespace Group5_API_Project.DTO
{
    public class ProductResponseDTO
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public CategoryDTO Categories { get; set; }
        public SupplierDTO Suppliers { get; set; }
    }
}
