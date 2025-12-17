using Microsoft.Extensions.Logging;
using TaskManagement.Domain;
using TaskManagement.InfraStructure;
using TaskManagement.Repositories;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly ILogger<TaskService> _logger;
        public TaskService(ITaskRepository repository, ILogger<TaskService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Completing Task: {ex.Message}");
                throw;
            }
        }

        public async Task<TaskItem?> GetTaskAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Getting Task: {ex.Message}");
                throw;
            }
        }

        public async Task CreateTaskAsync(TaskItem task)
        {
            try
            {
                await _repository.AddAsync(task);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Creating Task: {ex.Message}");
                throw;
            }
        }

        public async Task CompleteTaskAsync(int id)
        {
            try
            {
                var task = await _repository.GetByIdAsync(id);
                if (task == null) return;
                task.IsCompleted = true;
                await _repository.UpdateAsync(task);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Updating Task: {ex.Message}");
                throw;
            }
        }
    }
}
