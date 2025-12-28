using Microsoft.AspNetCore.Mvc;
using SchoolTasks.Core.Entities;
using SchoolTasks.Core.Services;
using System.Collections.Generic;

namespace SchoolTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet] public ActionResult<IEnumerable<Teacher>> GetAll() => Ok(_teacherService.GetList());

        [HttpGet("{id}")]
        public ActionResult<Teacher> GetById(int id)
        {
            var teacher = _teacherService.GetById(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Teacher teacher)
        {
            var newTeacher = _teacherService.Add(teacher);
            return CreatedAtAction(nameof(GetById), new { id = newTeacher.Id }, newTeacher);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Teacher teacher)
        {
            var updated = _teacherService.Update(id, teacher);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_teacherService.Delete(id)) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] string status)
        {
            var updated = _teacherService.UpdateStatus(id, status);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
    }
}