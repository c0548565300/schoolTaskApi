using SchoolTasks.Core.Entities;
using System.Collections.Generic;

namespace SchoolTasks.Core.Services
{
    public interface ITeacherService
    {
        List<Teacher> GetList();
        Teacher GetById(int id);
        Teacher Add(Teacher teacher);
        Teacher Update(int id, Teacher teacher);
        bool Delete(int id);
        Teacher UpdateStatus(int id, string status);
    }
}