using SchoolTasksAPI.Entities;
using SchoolTasksAPI.Data;
using System.Collections.Generic;

namespace SchoolTasksAPI.Tests
{
    public class FakeContext : IDataContext
    {
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Assignment> Assignments { get; set; }

        public FakeContext()
        {
            Students = new List<Student>
            {
                new Student { Id = 1, Name = "Fake Student 1", Email = "fake1@mail.com", Status = "Active" },
                new Student { Id = 2, Name = "Fake Student 2", Email = "fake2@mail.com", Status = "Inactive" }
            };

            Teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "Fake Teacher 1", Email = "teacher1@mail.com", Status = "Active" }
            };

            Assignments = new List<Assignment>
            {
                new Assignment { Id = 1, Title = "Fake Assignment", Description = "Test", TeacherId = 1, Status = "NotSubmitted", Grade = null }
            };
        }
    }
}
