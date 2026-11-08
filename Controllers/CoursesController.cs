using CourseManagementSystem.Data;
using CourseManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/courses
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .OrderBy(c => c.Title)
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    c.Description,
                    c.Price,
                    c.DurationInHours,
                    c.CategoryId,
                    CategoryName = c.Category.Name,
                    c.InstructorId,
                    InstructorName = c.Instructor.FullName
                })
                .ToListAsync();

            return Ok(courses);
        }

        // GET: api/courses/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .Where(c => c.Id == id)
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    c.Description,
                    c.Price,
                    c.DurationInHours,
                    c.CategoryId,
                    CategoryName = c.Category.Name,
                    c.InstructorId,
                    InstructorName = c.Instructor.FullName
                })
                .FirstOrDefaultAsync();

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        // POST: api/courses
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            var categoryExists =
                await _context.Categories.AnyAsync(c => c.Id == course.CategoryId);

            if (!categoryExists)
                return BadRequest("Category does not exist.");

            var instructorExists =
                await _context.Instructors.AnyAsync(i => i.Id == course.InstructorId);

            if (!instructorExists)
                return BadRequest("Instructor does not exist.");

            _context.Courses.Add(course);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = course.Id },
                course);
        }

        // PUT: api/courses/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Course course)
        {
            var existingCourse =
                await _context.Courses.FindAsync(id);

            if (existingCourse == null)
                return NotFound();

            var categoryExists =
                await _context.Categories.AnyAsync(c => c.Id == course.CategoryId);

            if (!categoryExists)
                return BadRequest("Category does not exist.");

            var instructorExists =
                await _context.Instructors.AnyAsync(i => i.Id == course.InstructorId);

            if (!instructorExists)
                return BadRequest("Instructor does not exist.");

            existingCourse.Title = course.Title;
            existingCourse.Description = course.Description;
            existingCourse.Price = course.Price;
            existingCourse.DurationInHours = course.DurationInHours;
            existingCourse.CategoryId = course.CategoryId;
            existingCourse.InstructorId = course.InstructorId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/courses/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course =
                await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            var hasEnrollments =
                await _context.Enrollments.AnyAsync(e => e.CourseId == id);

            if (hasEnrollments)
            {
                return Conflict(
                    "Cannot delete this course because it has enrollments.");
            }

            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}