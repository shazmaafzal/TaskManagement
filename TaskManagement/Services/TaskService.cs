using TaskManagement.Domain;
using TaskManagement.Repositories;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem?> GetTaskAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateTaskAsync(TaskItem task)
        {
            await _repository.AddAsync(task);
        }

        public async Task CompleteTaskAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return;
            task.IsCompleted = true;
            await _repository.UpdateAsync(task);
        }
    }
}
