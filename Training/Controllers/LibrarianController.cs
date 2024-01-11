using Microsoft.AspNetCore.Mvc;
using Training.Model;
using Training.Repository.Interfaces.BookWarehouse;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Controllers
{
    [ApiController]
    [Route("api/librarian/[action]")]
    public class LibrarianController : Controller
    {
        private readonly ILibrarianService _librarianService;
        private readonly AppDbContext _context;

        public LibrarianController(ILibrarianService librarianService, AppDbContext context)
        {
            _librarianService = librarianService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var datas = _librarianService.GetAll();
            return new OkObjectResult(datas);
        }

        [HttpGet]
        public IActionResult GetAllByName(string keyword)
        {
           var datas = _librarianService.GetAllByName(keyword);
            return new OkObjectResult(datas);
        }

        [HttpPost]
        public IActionResult AddEntity(LibrarianViewModel librarianViewModel)
        {
            if (ModelState.IsValid)
            {
                _librarianService.Add(librarianViewModel);
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEntity(LibrarianViewModel librarianViewModel)
        {
            if (ModelState.IsValid)
            {
                _librarianService.Update(librarianViewModel);
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _librarianService.Delete(id);
            return Ok();
        }
    }
}