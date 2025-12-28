namespace SchoolTasks.Core.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public string Status { get; set; } // NotSubmitted / Submitted / Graded
        public int? Grade { get; set; } // Optional
    }
}

