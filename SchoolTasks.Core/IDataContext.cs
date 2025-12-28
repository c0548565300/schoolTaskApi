using Microsoft.EntityFrameworkCore; // חובה בשביל DbSet
using SchoolTasks.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolTasks.Core
{
    public interface IDataContext
    {
        // שינינו מ-List ל-DbSet
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Assignment> Assignments { get; set; }

        // הוספנו את הפונקציה ששומרת את השינויים ב-DB
        int SaveChanges();

        // (אופציונלי אך מומלץ) שמירה אסינכרונית
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}