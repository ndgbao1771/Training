using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Training.Service.Implement.BookWarehouse;
using Training.Service.Interfaces;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Controllers
{
    [ApiController]
    [Route("api/author/[action]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var datas = _authorService.GetById(id);
            return new ObjectResult(datas);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _authorService.GetAll();
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
                _authorService.Delete(id);
                return new OkObjectResult(id);
            }
        }

        [HttpPost]
        public IActionResult AddEntity(AuthorViewModel authorViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            _authorService.Add(authorViewModel);
            return new OkObjectResult(authorViewModel);
        }

        [HttpPut]
        public IActionResult UpdateEntity(AuthorViewModel authorViewModel)
        {
            if (authorViewModel.Id == 0)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                _authorService.Update(authorViewModel);
            }
            return new OkObjectResult(authorViewModel);
        }
    }
}
