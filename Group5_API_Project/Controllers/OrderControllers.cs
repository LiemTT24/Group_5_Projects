using AutoMapper;
using Group5_API_Project.DTO;
using Group5_API_Project.Models;
using Group5_API_Project.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace Group5_API_Project.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderControllers : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;

        public OrderControllers(IOrderServices orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var order = await _orderServices.GetAllAsync();
            if (order is null)
            {
                return NotFound("The Order List is empty...");
            }
            var o = _mapper.Map<List<Order>, List<OrderDTO>>(order);
            return StatusCode(StatusCodes.Status200OK, o);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleOrder(int id)
        {
            var order = await _orderServices.GetAsync(id);
            if (order is null)
            {
                return NotFound("The Order does not existed!");
            }
            var o = _mapper.Map<Order, OrderDTO>(order);
            return StatusCode(StatusCodes.Status200OK, o);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder(OrderDTO order)
        {
            var categories = _mapper.Map<OrderDTO, Order>(order);
            await _orderServices.CreateAsync(categories);
            return StatusCode(StatusCodes.Status201Created, categories);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderDTO order)
        {
            bool check = await _orderServices.AnyAsync(order.OrderID);
            if (!check)
            {
                return NotFound("The OrderID does not exist.");
            }
            var categories = _mapper.Map<OrderDTO, Order>(order);
            await _orderServices.UpdateAsync(categories);
            return StatusCode(StatusCodes.Status204NoContent, categories);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            bool check = await _orderServices.AnyAsync(id);
            if (!check)
            {
                return NotFound("The OrderID does not exist.");
            }
            var c = await _orderServices.GetAsync(id);
            await _orderServices.DeleteAsync(c);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
