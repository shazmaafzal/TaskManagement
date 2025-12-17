namespace TaskManagement.InfraStructure
{
    public class TaskNotificationService : BackgroundService
    {
        private readonly ILogger<TaskNotificationService> _logger;
        public TaskNotificationService(ILogger<TaskNotificationService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("TaskNotificationService running at {time}", DateTime.UtcNow);
                await Task.Delay(30000, stoppingToken);
            }
        }
    }
}
