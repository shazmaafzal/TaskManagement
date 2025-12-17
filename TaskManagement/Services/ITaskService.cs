using TaskManagement.Domain;

namespace TaskManagement.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetTasksAsync();
        Task<TaskItem?> GetTaskAsync(int id);
        Task CreateTaskAsync(TaskItem task);
        Task CompleteTaskAsync(int id);
    }
}
