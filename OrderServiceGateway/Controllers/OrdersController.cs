using Microsoft.AspNetCore.Mvc;
using OrderServiceGateway.CommonBO;
using OrderServiceGateway.Interfaces;


namespace OrderServiceGateway.Controllers
{
    public class OrdersController : BaseAPIController
    {
        protected ResponseMessegeBO _response;
        private IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            this._response = new ResponseMessegeBO();
            _orderService = orderService;   
        }


        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<OrderBO> order = await _orderService.GetOrder();
                return _response.Result = order;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet("{orderId}")]
        public async Task<object> Get(int orderId)
        {
            try
            {
                OrderBO order = await _orderService.GetOrderById(orderId);
                return _response.Result = order;
            }
             catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet("search")]
        public async Task<object> Search(int key)
        {
            try
            {
                IEnumerable<OrderBO> order = await _orderService.SearchOrder(key);
                return _response.Result = order;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPost("create")]
        public async Task<object> Create(OrderBO orderBo)
        {
            try
                {
                    var order = await _orderService.CreateOrder(orderBo);
                    return _response.Result = order;
                } 
             catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
