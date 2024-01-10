using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Training.Service.Interfaces;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Controllers
{
    [ApiController]
    [Route("api/bookCategory/[action]")]
    public class BookcategoryController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;

        public BookcategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var datas = _bookCategoryService.GetById(id);
            return new ObjectResult(datas);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _bookCategoryService.GetAll();
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
                _bookCategoryService.Delete(id);
                return new OkObjectResult(id);
            }
        }

        [HttpPost]
        public IActionResult AddEntity(BookCategoryViewModel bookCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            _bookCategoryService.Add(bookCategoryViewModel);
            return new OkObjectResult(bookCategoryViewModel);
        }

        [HttpPut]
        public IActionResult UpdateEntity(BookCategoryViewModel bookCategoryViewModel)
        {
            if (bookCategoryViewModel.Id == 0)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                _bookCategoryService.Update(bookCategoryViewModel);
            }
            return new OkObjectResult(bookCategoryViewModel);
        }
    }
}