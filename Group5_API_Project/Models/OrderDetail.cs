namespace Group5_API_Project.Models
{
    public class OrderDetail
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public string? ProductName { get; set; }

        public int QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public int Discount { get; set; }
    }
}
