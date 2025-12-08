using Microsoft.AspNetCore.Mvc;
using SchoolTasksAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private static List<Teacher> Teachers = new List<Teacher>();

        [HttpGet]
        public IActionResult GetAll() => Ok(Teachers);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Teacher teacher)
        {
            teacher.Id = Teachers.Count > 0 ? Teachers.Max(t => t.Id) + 1 : 1;
            Teachers.Add(teacher);
            return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Teacher teacher)
        {
            var existing = Teachers.FirstOrDefault(t => t.Id == id);
            if (existing == null) return NotFound();
            existing.Name = teacher.Name;
            existing.Email = teacher.Email;
            existing.Status = teacher.Status;
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = Teachers.FirstOrDefault(t => t.Id == id);
            if (existing == null) return NotFound();
            Teachers.Remove(existing);
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] string status)
        {
            var teacher = Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null) return NotFound();
            teacher.Status = status;
            return Ok(teacher);
        }
    }
}
