using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Model;
using TaskManager.Services;


namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskManagerController : ControllerBase
    {
        private readonly TaskServices _taskServices;

        public TaskManagerController(TaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet]
        public ActionResult<List<Taskitem>> GetAllTasks()
        {
            return _taskServices.GetAllTasks();
        }

        [HttpGet("{id}")]
        public ActionResult<Taskitem> GetTaskById(int id)
        {
            var task = _taskServices.GetTaskById(id);
            if (task == null)
            {
                return new NotFoundResult();
            }
            return task;
        }

        [HttpPost]
        public ActionResult<Taskitem> AddTask(Taskitem item)
        {
            var createdTask = _taskServices.Add(item);
            return new CreatedAtActionResult(nameof(GetTaskById), "TaskManager", new { id = createdTask.Id }, createdTask);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, Taskitem item)
        {
            var existingTask = _taskServices.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }
            _taskServices.Update(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var res = _taskServices.Delete(id);
            if (!res)
            {
                return NotFound();
            }
            return NoContent();
        }

        }
}
