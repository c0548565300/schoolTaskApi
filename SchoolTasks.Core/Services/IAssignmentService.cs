using SchoolTasks.Core.Entities;
using System.Collections.Generic;

namespace SchoolTasks.Core.Services
{
    public interface IAssignmentService
    {
        List<Assignment> GetList();
        Assignment GetById(int id);
        Assignment Add(Assignment assignment);
        Assignment Update(int id, Assignment assignment);
        bool Delete(int id);
        Assignment UpdateStatus(int id, Assignment statusUpdate); // כאן מקבלים אובייקט כי מעדכנים גם ציון
    }
}