using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service.Interfaces;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllStudents());

      
        [HttpPost]
        public async Task<IActionResult> Add(Student s)
        {
            await _service.AddStudent(s);
            return Ok("Added");
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student s)
        {
            await _service.UpdateStudent(id, s);
            return Ok("Updated");
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteStudent(id);
            return Ok("Deleted");
        }
    }
}
