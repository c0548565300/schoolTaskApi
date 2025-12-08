using Microsoft.AspNetCore.Mvc;
using SchoolTasksAPI.Data; // חובה
using SchoolTasksAPI.Entities;
using System.Linq;

namespace SchoolTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        // שימוש ב-DataContext במקום רשימה סטטית
        private readonly DataContext _context = new DataContext();

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Teachers);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Teacher teacher)
        {
            teacher.Id = _context.Teachers.Count > 0 ? _context.Teachers.Max(t => t.Id) + 1 : 1;
            _context.Teachers.Add(teacher);
            return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Teacher teacher)
        {
            var existing = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (existing == null) return NotFound();

            existing.Name = teacher.Name;
            existing.Email = teacher.Email;
            existing.Status = teacher.Status;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (existing == null) return NotFound();

            _context.Teachers.Remove(existing);
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] string status)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null) return NotFound();

            teacher.Status = status;
            return Ok(teacher);
        }
    }
}