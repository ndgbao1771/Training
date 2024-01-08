using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Training.Service.Interfaces;
using Training.Service.ViewModel;

namespace Training.Controllers
{
    [ApiController]
    [Route("api/todo/[action]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var datas = _todoService.GetById(id);
            return new ObjectResult(datas);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _todoService.GetAll();
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
                _todoService.Delete(id);
                return new OkObjectResult(id);
            }
        }

        [HttpPost]
        public IActionResult AddEntity(TodoViewModel todoViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            _todoService.Add(todoViewModel);
            return new OkObjectResult(todoViewModel);
        }

        [HttpPut]
        public IActionResult UpdateEntity(TodoViewModel todoViewModel)
        {
            if(todoViewModel.Id == 0)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                _todoService.Update(todoViewModel);
            }
            return new OkObjectResult(todoViewModel);
        }

    }
}
