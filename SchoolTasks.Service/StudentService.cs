using SchoolTasks.Core;
using SchoolTasks.Core.Entities;
using SchoolTasks.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTasks.Service
{
    public class StudentService : IStudentService
    {
        private readonly IDataContext _context;

        public StudentService(IDataContext context)
        {
            _context = context;
        }

        public List<Student> GetList()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public Student Add(Student student)
        {
            
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;

        }

        public Student Update(int id, Student student)
        {
            var existing = GetById(id);
            if (existing == null) return null;

            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Status = student.Status;
            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            _context.Students.Remove(existing);
            _context.SaveChanges();
            return true;
        }

        public Student UpdateStatus(int id, string status)
        {
            var existing = GetById(id);
            if (existing == null) return null;

            existing.Status = status;
            _context.SaveChanges();
            return existing;
        }
    }
}