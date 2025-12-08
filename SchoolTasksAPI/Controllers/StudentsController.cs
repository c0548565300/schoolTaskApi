using Microsoft.AspNetCore.Mvc;
using SchoolTasksAPI.Data; // חובה להוסיף כדי להכיר את DataContext
using SchoolTasksAPI.Entities;
using System.Linq;

namespace SchoolTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        // יצירת מופע של DataContext שמחזיק את הנתונים
        private readonly DataContext _context = new DataContext();

        // GET api/students
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Students);
        }

        // GET api/students/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // POST api/students
        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            // יצירת ID חדש
            student.Id = _context.Students.Count > 0 ? _context.Students.Max(s => s.Id) + 1 : 1;

            _context.Students.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // PUT api/students/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            var existing = _context.Students.FirstOrDefault(s => s.Id == id);
            if (existing == null) return NotFound();

            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Status = student.Status;

            return Ok(existing);
        }

        // DELETE api/students/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Students.FirstOrDefault(s => s.Id == id);
            if (existing == null) return NotFound();

            _context.Students.Remove(existing);
            return NoContent();
        }

        // PUT api/students/{id}/status
        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] string status)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            student.Status = status;
            return Ok(student);
        }
    }
}