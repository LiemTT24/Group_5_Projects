using Group5_API_Project.DataAccess;
using Group5_API_Project.Models;
using Group5_API_Project.Services.CommonServices;
using Microsoft.EntityFrameworkCore;

namespace Group5_API_Project.Services.ProductServices
{
    public class ProductServices : CommonServices<ApplicationDbContext, Product>, IProductServices
    {
        private readonly ApplicationDbContext _context;
        public ProductServices(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> AllProducts()
        {
            var products = await _context.Products.Include(p => p.Categories).ToListAsync();
            return products;
        }

        public async Task<Product> SingleProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Categories).SingleOrDefaultAsync(p => p.ProductID == id);
            return product;
        }

        public async Task<IEnumerable<Product>> SearchProducts(string name)
        {
            IQueryable<Product> _product = _context.Products;
            if (!string.IsNullOrEmpty(name))
            {
                _product = _product.Where(x => x.ProductName.Contains(name));
            }
            return await _product.ToArrayAsync();
        }
    }
}
