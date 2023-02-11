using Group5_API_Project.Models;
using Group5_API_Project.Services.CommonServices;

namespace Group5_API_Project.Services.ProductServices
{
    public interface IProductServices : ICommonServices<Product>
    {
        Task<List<Product>> AllProducts();
        Task<Product> SingleProduct(int id);
        Task<IEnumerable<Product>> SearchProducts(string name);
    }
}
