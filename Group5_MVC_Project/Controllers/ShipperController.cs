using Group5_API_Project.DTO;
using Group5_API_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Group5_MVC_Project.Controllers
{
    public class ShipperController : Controller
    {
        private readonly HttpClient _client;
        private readonly string ApiUrl = "";
        private readonly string ApiUrlChecking = "";

        public ShipperController()
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:44321/api/orders";
            ApiUrl = "https://localhost:44321/api/orderchecking";
        }

        public async Task<IActionResult> Dashboard()
        {
            var response = await _client.GetAsync(ApiUrl);
            var data = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<OrderDTO>>(data);
            return View(orders);
        }

        public IActionResult ShipperUpdate(int? id)
        {
            var response = _client.GetStringAsync(ApiUrl + "/" + id).GetAwaiter().GetResult();
            var order = JsonConvert.DeserializeObject<OrderDTO>(response);

            var res = _client.GetStringAsync(ApiUrlChecking).GetAwaiter().GetResult();
            var checking = JsonConvert.DeserializeObject<List<OrderCheckingDTO>>(res);
            ViewData["OrderChecking"] = new SelectList(checking, "OrderCheckingID", "OrderCheckingName", order.OrderStatus.OrderCheckingID);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShipperUpdate(int id, int checkID, Order order)
        {
            order.OrderCheckingID = checkID;
            if (id != order.OrderCheckingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _client.PutAsJsonAsync(ApiUrl, order);
                return RedirectToAction(nameof(Index));
            }
            var res = _client.GetStringAsync(ApiUrlChecking).GetAwaiter().GetResult();
            var categories = JsonConvert.DeserializeObject<List<CategoryDTO>>(res);
            ViewData["OrderChecking"] = new SelectList(categories, "OrderCheckingID", "OrderCheckingName", order.OrderCheckingID);
            return View(order);
        }
    }
}
