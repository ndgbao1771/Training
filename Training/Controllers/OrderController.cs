using Microsoft.AspNetCore.Mvc;
using Training.Service.Interfaces;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Controllers
{
    [ApiController]
    [Route("api/order/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var datas = _orderService.GetAll();
            return new OkObjectResult(datas);
        }

        [HttpPost]
        public IActionResult Add(OrderViewModel orderViewModel)
        {
            _orderService.Add(orderViewModel);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(OrderViewModel orderViewModel)
        {
            _orderService.Update(orderViewModel);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return Ok();
        }
    }
}