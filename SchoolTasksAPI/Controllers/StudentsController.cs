using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using SchoolTasksAPI.Entities;

namespace SchoolTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        // שדה סטטי לשמירת התלמידים
        private static List<Student> Students = new List<Student>();

        // קונסטרקטור - טוען נתונים התחלתיים אם הרשימה ריקה
        public StudentsController()
        {
            if (!Students.Any())
            {
                var jsonData = System.IO.File.ReadAllText("SeedData.json");
                var doc = JsonDocument.Parse(jsonData);
                var studentsJson = doc.RootElement.GetProperty("students");
                Students = JsonSerializer.Deserialize<List<Student>>(studentsJson.GetRawText());
            }
        }

        // GET api/students
        [HttpGet]
        public IActionResult GetAll() => Ok(Students);

        // GET api/students/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // POST api/students
        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            student.Id = Students.Count > 0 ? Students.Max(s => s.Id) + 1 : 1;
            Students.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // PUT api/students/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            var existing = Students.FirstOrDefault(s => s.Id == id);
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
            var existing = Students.FirstOrDefault(s => s.Id == id);
            if (existing == null) return NotFound();
            Students.Remove(existing);
            return NoContent();
        }

        // PUT api/students/{id}/status
        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] string status)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            student.Status = status;
            return Ok(student);
        }
    }
}
