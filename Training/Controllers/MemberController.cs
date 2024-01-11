using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Training.Model;
using Training.Service.Implement.BookWarehouse;
using Training.Service.Interfaces;
using Training.Service.ViewModel;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Controllers
{
    [ApiController]
    [Route("api/member/[action]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly AppDbContext _context;

        public MemberController(IMemberService memberService, AppDbContext context)
        {
            _memberService = memberService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMember() 
        {
            var datas =_memberService.GetMembers();
            return new OkObjectResult(datas);
        }

        [HttpGet]
        public IActionResult GetMemberByName(string keyword) 
        {
            var datas = _memberService.GetMemberByName(keyword);
            return new OkObjectResult(datas);
        }

        [HttpPost]
        public IActionResult AddEntity(MemberViewModel memberViewModel)
        {
            if (ModelState.IsValid)
            {
                _memberService.Add(memberViewModel);
                return Ok(memberViewModel);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateEntity(MemberViewModel memberViewModel)
        {
            if (ModelState.IsValid)
            {
                if (memberViewModel.Id == 0)
                {
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    return new BadRequestObjectResult(allErrors);
                }
                else
                {
                    _memberService.Update(memberViewModel);
                    return Ok(memberViewModel);
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            _memberService.Delete(id);
            return Ok();
        }
    }
}
