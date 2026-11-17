using EF_Core_Sample.Data;
using EF_Core_Sample.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using EF_Core_Sample.DTO;

namespace EF_Core_Sample.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {

            var students = _context.Students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Age = s.Age,
                CourseName = s.course!.Name
            });
            
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> oneStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            
            if(student != null)
            {
                return Ok(student);
            }

            return NotFound("The student not exist");
        }

        [HttpPost]
        public async Task<IActionResult> addStudents(Students student)
        {
            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> updateStudent(int id,Students student)
        {
            var item = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if(item != null)
            {
                item.Name = student.Name;
                item.Age = student.Age;
                item.DOB = student.DOB;
                item.Email = student.Email;
                item.Phone = student.Phone;
                item.Password = student.Password;
                item.CourseId = student.CourseId;

                await _context.SaveChangesAsync();

                return Ok(student);

            }

            return BadRequest("something is wrong");
        }

        [HttpDelete]
        public async Task<IActionResult> deleteStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if(student != null)
            {
                _context.Students.Remove(student);

                await _context.SaveChangesAsync();

                return Ok("Successfully Deleted");
            }

            return NotFound("Student not exist");
        }


    }
}
