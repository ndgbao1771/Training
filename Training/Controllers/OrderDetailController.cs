using Microsoft.AspNetCore.Mvc;
using Training.Service.Interfaces;

namespace Training.Controllers
{
    [ApiController]
    [Route("api/orderdetail/[action]")]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var datas = _orderDetailService.GetAll();
            return new OkObjectResult(datas);
        }
    }
}
