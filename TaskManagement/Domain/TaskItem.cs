using System.ComponentModel;

namespace TaskManagement.Domain
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
