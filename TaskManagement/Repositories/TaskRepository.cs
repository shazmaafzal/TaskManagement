using TaskManagement.Domain;

namespace TaskManagement.Repositories
{
    public class TaskRepository
    {
        private static readonly List<TaskItem> _tasks = new();

        public Task<IEnumerable<TaskItem>> GetAllAsync() => Task.FromResult(_tasks.AsEnumerable());

        public Task<TaskItem?> GetByIdAsync(int id) => Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));

        public Task AddAsync(TaskItem task)
        {
            task.Id = _tasks.Count + 1;
            _tasks.Add(task);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TaskItem task) => Task.CompletedTask;

        public Task DeleteAsync(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null) _tasks.Remove(task);
            return Task.CompletedTask;
        }
    }
}
