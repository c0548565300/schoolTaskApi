using Microsoft.AspNetCore.Mvc;
using SchoolTasks.Core.Entities;
using SchoolTasks.Core.Services;
using System.Collections.Generic;

namespace SchoolTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        // המשתנה שיחזיק את ה-Service
        private readonly IStudentService _studentService;

        // הזרקת ה-Service דרך הבנאי (Constructor Injection)
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(_studentService.GetList());
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Student student)
        {
            var newStudent = _studentService.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Student student)
        {
            var updatedStudent = _studentService.Update(id, student);
            if (updatedStudent == null) return NotFound();
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _studentService.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] string status)
        {
            var updatedStudent = _studentService.UpdateStatus(id, status);
            if (updatedStudent == null) return NotFound();
            return Ok(updatedStudent);
        }
    }
}