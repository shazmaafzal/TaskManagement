using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    //[Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        public TaskController(TaskService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetTasksAsync());

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            await _service.CreateTaskAsync(task);
            return Ok(task);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            await _service.CompleteTaskAsync(id);
            return NoContent();
        }
    }
}
