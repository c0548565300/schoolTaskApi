using SchoolTasksAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTasksAPI.Data
{
    public class DataContext
    {
        // מגדירים את ה Lists כ-Properties
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Assignment> Assignments { get; set; }

        // הקונסטרקטור מאתחל את הרשימות בנתוני דמה פנימיים
        public DataContext()
        {
            // נתוני דמה (Seed Data)
            Students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice Cohen", Email = "alice@example.com", Status = "Active" },
                new Student { Id = 2, Name = "David Levy", Email = "david@example.com", Status = "Active" }
            };

            Teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "Dr. Ben Levi", Email = "ben@example.com", Status = "Active" },
                new Teacher { Id = 2, Name = "Prof. Sara Gold", Email = "sara@example.com", Status = "Active" }
            };

            Assignments = new List<Assignment>
            {
                new Assignment { Id = 1, Title = "Math Homework 1", Description = "Complete 1-10", TeacherId = 1, Status = "NotSubmitted", Grade = null },
                new Assignment { Id = 2, Title = "History Project", Description = "Write report", TeacherId = 2, Status = "NotSubmitted", Grade = null }
            };
        }
    }
}