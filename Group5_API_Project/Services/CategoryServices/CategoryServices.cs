using Group5_API_Project.DataAccess;
using Group5_API_Project.Models;
using Group5_API_Project.Services.CommonServices;

namespace Group5_API_Project.Services.CategoryServices
{
    public class CategoryServices : CommonServices<ApplicationDbContext, Category>, ICategoryServices
    {
        public CategoryServices(ApplicationDbContext options) : base(options) { }
    }
}
