using Microsoft.AspNetCore.Mvc;
using SchoolTasksAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private static List<Assignment> Assignments = new List<Assignment>();

        [HttpGet]
        public IActionResult GetAll() => Ok(Assignments);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var assignment = Assignments.FirstOrDefault(a => a.Id == id);
            if (assignment == null) return NotFound();
            return Ok(assignment);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Assignment assignment)
        {
            assignment.Id = Assignments.Count > 0 ? Assignments.Max(a => a.Id) + 1 : 1;
            Assignments.Add(assignment);
            return CreatedAtAction(nameof(GetById), new { id = assignment.Id }, assignment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Assignment assignment)
        {
            var existing = Assignments.FirstOrDefault(a => a.Id == id);
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
            var existing = Assignments.FirstOrDefault(a => a.Id == id);
            if (existing == null) return NotFound();
            Assignments.Remove(existing);
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] Assignment updated)
        {
            var assignment = Assignments.FirstOrDefault(a => a.Id == id);
            if (assignment == null) return NotFound();
            assignment.Status = updated.Status;
            assignment.Grade = updated.Grade ?? assignment.Grade;
            return Ok(assignment);
        }
    }
}
