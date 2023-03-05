using Group5_API_Project.DataAccess;
using Group5_API_Project.Models;
using Group5_API_Project.Services.CommonServices;
using Group5_API_Project.Services.OrderServices;

namespace Group5_API_Project.Services.OrderCheckingServices
{
    public class OrderCheckingServices : CommonServices<ApplicationDbContext, OrderChecking>, IOrderCheckingServices
    {
        public OrderCheckingServices(ApplicationDbContext options) : base(options) { }
    }
}
