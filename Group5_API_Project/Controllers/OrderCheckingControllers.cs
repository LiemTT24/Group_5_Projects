using AutoMapper;
using Group5_API_Project.DTO;
using Group5_API_Project.Models;
using Group5_API_Project.Services.OrderCheckingServices;
using Group5_API_Project.Services.OrderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Group5_API_Project.Controllers
{
    [Route("api/orderchecking")]
    [ApiController]
    public class OrderCheckingControllers : ControllerBase
    {
        private readonly IOrderCheckingServices _checking;
        private readonly IMapper _mapper;

        public OrderCheckingControllers(IOrderCheckingServices checking, IMapper mapper)
        {
            _checking = checking;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderChecking()
        {
            var check = await _checking.GetAllAsync();
            if (check is null)
            {
                return NotFound("The OrderChecking List is empty...");
            }
            var o = _mapper.Map<List<OrderChecking>, List<OrderCheckingDTO>>(check);
            return StatusCode(StatusCodes.Status200OK, o);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleOrderChecking(int id)
        {
            var order = await _checking.GetAsync(id);
            if (order is null)
            {
                return NotFound("The OrderChecking does not existed!");
            }
            var o = _mapper.Map<OrderChecking, OrderCheckingDTO>(order);
            return StatusCode(StatusCodes.Status200OK, o);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder(OrderCheckingDTO order)
        {
            var categories = _mapper.Map<OrderCheckingDTO, OrderChecking>(order);
            await _checking.CreateAsync(categories);
            return StatusCode(StatusCodes.Status201Created, categories);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderCheckingDTO order)
        {
            bool check = await _checking.AnyAsync(order.OrderCheckingID);
            if (!check)
            {
                return NotFound("The OrderCheckingID does not exist.");
            }
            var categories = _mapper.Map<OrderCheckingDTO, OrderChecking>(order);
            await _checking.UpdateAsync(categories);
            return StatusCode(StatusCodes.Status204NoContent, categories);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            bool check = await _checking.AnyAsync(id);
            if (!check)
            {
                return NotFound("The OrderCheckingID does not exist.");
            }
            var c = await _checking.GetAsync(id);
            await _checking.DeleteAsync(c);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
