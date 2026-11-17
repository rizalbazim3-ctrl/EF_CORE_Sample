using EF_Core_Sample.Data;
using Microsoft.AspNetCore.Mvc;
using EF_Core_Sample.Models;
using Microsoft.EntityFrameworkCore;


namespace EF_Core_Sample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourse()
        {
            return Ok(await _context.Course.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> SingleCourse(int id)
        {
            var item = await _context.Course.FirstOrDefaultAsync(x => x.Id == id);

            if(item != null)
            {
                return Ok(item);
            }

            return NotFound("The Course Not Exist");
        }
        [HttpPost]
        public async Task<IActionResult> insertCourse(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return Ok(course);
        }
        [HttpPut]
        public async Task<IActionResult> updateCourse(int id, Course course)
        {
            var update = await _context.Course.FirstOrDefaultAsync(x => x.Id == id);
            if(update != null)
            {
                update.Name = course.Name;

                await _context.SaveChangesAsync();

                return Ok(update);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> deleteCourse(int id)
        {
            var deleteItem = await _context.Course.FirstOrDefaultAsync(x => x.Id == id);

            if(deleteItem != null)
            {
                _context.Course.Remove(deleteItem);

                await _context.SaveChangesAsync();

                return Ok("successfully deleted");
            }
            return NotFound();
        }
    }
}
