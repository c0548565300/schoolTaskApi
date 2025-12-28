using SchoolTasks.Core;
using SchoolTasks.Core.Entities;
using SchoolTasks.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTasks.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IDataContext _context;

        public TeacherService(IDataContext context)
        {
            _context = context;
        }

        public List<Teacher> GetList()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetById(int id)
        {
            // שליפה ישירה ויעילה מה-DB
            return _context.Teachers.FirstOrDefault(t => t.Id == id);
        }

        public Teacher Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges(); // שמירה ב-DB
            return teacher;
        }

        public Teacher Update(int id, Teacher teacher)
        {
            var existing = GetById(id);
            if (existing == null) return null;

            existing.Name = teacher.Name;
            existing.Email = teacher.Email;
            existing.Status = teacher.Status;

            _context.SaveChanges(); // שמירה ב-DB
            return existing;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            _context.Teachers.Remove(existing);
            _context.SaveChanges(); // שמירה ב-DB
            return true;
        }

        public Teacher UpdateStatus(int id, string status)
        {
            var existing = GetById(id);
            if (existing == null) return null;

            existing.Status = status;
            _context.SaveChanges(); // שמירה ב-DB
            return existing;
        }
    }
}