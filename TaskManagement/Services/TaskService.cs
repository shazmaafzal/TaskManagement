using TaskManagement.Domain;
using TaskManagement.Repositories;

namespace TaskManagement.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository repository) => _repository = repository;

        public async Task<IEnumerable<TaskItem>> GetTasksAsync() => await _repository.GetAllAsync();

        public async Task<TaskItem?> GetTaskAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task CreateTaskAsync(TaskItem task) => await _repository.AddAsync(task);

        public async Task CompleteTaskAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return;
            task.IsCompleted = true;
            await _repository.UpdateAsync(task);
        }
    }
}
