using Microsoft.AspNetCore.Mvc;
using SchoolTasksAPI.Data; // חובה
using SchoolTasksAPI.Entities;
using System.Linq;

namespace SchoolTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        // שימוש ב-DataContext במקום רשימה סטטית
        private readonly DataContext _context = new DataContext();

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Assignments);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var assignment = _context.Assignments.FirstOrDefault(a => a.Id == id);
            if (assignment == null) return NotFound();
            return Ok(assignment);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Assignment assignment)
        {
            assignment.Id = _context.Assignments.Count > 0 ? _context.Assignments.Max(a => a.Id) + 1 : 1;
            _context.Assignments.Add(assignment);
            return CreatedAtAction(nameof(GetById), new { id = assignment.Id }, assignment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Assignment assignment)
        {
            var existing = _context.Assignments.FirstOrDefault(a => a.Id == id);
            if (existing == null) return NotFound();

            existing.Title = assignment.Title;
            existing.Description = assignment.Description;
            existing.TeacherId = assignment.TeacherId;
            existing.Status = assignment.Status;
            existing.Grade = assignment.Grade;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Assignments.FirstOrDefault(a => a.Id == id);
            if (existing == null) return NotFound();

            _context.Assignments.Remove(existing);
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] Assignment updated)
        {
            var assignment = _context.Assignments.FirstOrDefault(a => a.Id == id);
            if (assignment == null) return NotFound();

            assignment.Status = updated.Status;
            assignment.Grade = updated.Grade ?? assignment.Grade;

            return Ok(assignment);
        }
    }
}