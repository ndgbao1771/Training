using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Training.Service.Implement;
using Training.Service.Implement.BookWarehouse;
using Training.Service.Interfaces;
using Training.Service.ViewModel;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Controllers
{
    [ApiController]
    [Route("api/book/[action]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var datas = _bookService.GetById(id);
            return new ObjectResult(datas);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _bookService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new BadRequestResult();
            }
            else
            {
                _bookService.Delete(id);
                return new OkObjectResult(id);
            }
        }

        [HttpPost]
        public IActionResult AddEntity(BookViewUpdateModel bookViewUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            _bookService.Add(bookViewUpdateModel);
            return new OkObjectResult(bookViewUpdateModel);
        }

        [HttpPut]
        public IActionResult UpdateEntity(BookViewUpdateModel bookViewUpdateModel)
        {
            if (bookViewUpdateModel.Id == 0)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                _bookService.Update(bookViewUpdateModel);
            }
            return new OkObjectResult(bookViewUpdateModel);
        }
    }
}
