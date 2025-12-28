using SchoolTasks.Core.Entities;
using System.Collections.Generic;

namespace SchoolTasks.Core.Services
{
    public interface IStudentService
    {
        List<Student> GetList();
        Student GetById(int id);
        Student Add(Student student);
        Student Update(int id, Student student);
        bool Delete(int id);
        Student UpdateStatus(int id, string status);
    }
}