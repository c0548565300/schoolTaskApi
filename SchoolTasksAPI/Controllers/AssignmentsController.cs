using Microsoft.AspNetCore.Mvc;
using SchoolTasks.Core.Entities;
using SchoolTasks.Core.Services;
using System.Collections.Generic;

namespace SchoolTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet] public ActionResult<IEnumerable<Assignment>> GetAll() => Ok(_assignmentService.GetList());

        [HttpGet("{id}")]
        public ActionResult<Assignment> GetById(int id)
        {
            var assignment = _assignmentService.GetById(id);
            if (assignment == null) return NotFound();
            return Ok(assignment);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Assignment assignment)
        {
            var newAssignment = _assignmentService.Add(assignment);
            return CreatedAtAction(nameof(GetById), new { id = newAssignment.Id }, newAssignment);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Assignment assignment)
        {
            var updated = _assignmentService.Update(id, assignment);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_assignmentService.Delete(id)) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] Assignment updated)
        {
            var assignment = _assignmentService.UpdateStatus(id, updated);
            if (assignment == null) return NotFound();
            return Ok(assignment);
        }
    }
}