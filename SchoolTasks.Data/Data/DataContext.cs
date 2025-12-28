using Microsoft.EntityFrameworkCore;
using SchoolTasks.Core.Entities;
using SchoolTasks.Core;

namespace SchoolTasks.Data
{
    // 1. ירושה מ-DbContext (חובה בשביל EF)
    public class DataContext : DbContext, IDataContext
    {
        // 2. בנאי שמקבל את ההגדרות (options) ומעביר אותן לבנאי של האבא (base)
        // זה מחליף את ה-OnConfiguring שהמורה עשתה!
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // 3. הגדרת הטבלאות (DbSet במקום List)
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        // הערה חשובה: EF יודע לממש את ה-Lists של האינטרפייס באמצעות ה-DbSets האלה
    }
}