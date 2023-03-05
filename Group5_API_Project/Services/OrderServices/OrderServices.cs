using Group5_API_Project.DataAccess;
using Group5_API_Project.Models;
using Group5_API_Project.Services.CategoryServices;
using Group5_API_Project.Services.CommonServices;

namespace Group5_API_Project.Services.OrderServices
{
    public class OrderServices : CommonServices<ApplicationDbContext, Order>, IOrderServices
    {
        public OrderServices(ApplicationDbContext options) : base(options) { }
    }
}
