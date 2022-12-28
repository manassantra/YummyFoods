using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyFood.Web.CommonBO;
using YummyFood.Web.Interfaces;

namespace YummyFood.Web.Controllers
{

    public class OrdersController : Controller
    {
        private ILogger<OrdersController> _logger;
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            this._logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            string _token = HttpContext.Request.Cookies["yum_cId"];
            if (_token == null)
            {
                return (RedirectToAction("Login", "Authentication"));
            }
            var response = await _orderService.GetAllOrders<ResponseMessegeBO>(_token);
            List<OrderBO>? list = new();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<OrderBO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
