using SchoolTasks.Core;
using SchoolTasks.Core.Entities;
using SchoolTasks.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTasks.Service
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IDataContext _context;

        public AssignmentService(IDataContext context)
        {
            _context = context;
        }

        public List<Assignment> GetList()
        {
            return _context.Assignments.ToList();
        }

        public Assignment GetById(int id)
        {
            // שליפה ישירה ויעילה מה-DB
            return _context.Assignments.FirstOrDefault(a => a.Id == id);
        }

        public Assignment Add(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            _context.SaveChanges(); // שמירה ב-DB
            return assignment;
        }

        public Assignment Update(int id, Assignment assignment)
        {
            var existing = GetById(id);
            if (existing == null) return null;

            existing.Title = assignment.Title;
            existing.Description = assignment.Description;
            existing.TeacherId = assignment.TeacherId;
            existing.Status = assignment.Status;
            existing.Grade = assignment.Grade;

            _context.SaveChanges(); // שמירה ב-DB
            return existing;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            _context.Assignments.Remove(existing);
            _context.SaveChanges(); // שמירה ב-DB
            return true;
        }

        public Assignment UpdateStatus(int id, Assignment updatedInfo)
        {
            var existing = GetById(id);
            if (existing == null) return null;

            existing.Status = updatedInfo.Status;
            // עדכון ציון רק אם נשלח ערך חדש (לא חובה, תלוי בלוגיקה שלך)
            if (updatedInfo.Grade.HasValue)
            {
                existing.Grade = updatedInfo.Grade;
            }

            _context.SaveChanges(); // שמירה ב-DB
            return existing;
        }
    }
}