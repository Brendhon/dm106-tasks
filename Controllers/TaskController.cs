using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Services;

namespace Task.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
  // Logger
  private readonly ILogger<TaskController> _logger;

  // Task service
  private TaskService _taskService;

  // Constructor
  public TaskController(ILogger<TaskController> logger, TaskService taskService)
  {
    _logger = logger;
    _taskService = taskService;
  }

  // GET: api/Task
  [HttpGet]
  public IEnumerable<TaskModel> GetAll()
  {
    return _taskService.GetAll();
  }

  // GET: api/Task/5
  [HttpGet("{id}")]
  public ActionResult<TaskModel> GetById(int id)
  {
    TaskModel? task = _taskService.GetById(id);
    if (task is not null)
    {
      return Ok(task);
    }
    else
    {
      return NotFound();
    }
  }

  // POST: api/Task
  [HttpPost]
  public ActionResult Create(TaskModel newTask)
  {
    TaskModel task = _taskService.Create(newTask);
    return CreatedAtAction(nameof(GetById), new { id = task!.Id }, task);
  }

  // PUT: api/Task/5
  [HttpPut("{id}")]
  public ActionResult Update(int id, TaskModel task)
  {
    if (id != task.Id)
    {
      return BadRequest();
    }
    TaskModel? taskUpdated = _taskService.Update(id, task);
    if (taskUpdated is not null)
    {
      return Ok(taskUpdated);
    }
    return NotFound();
  }

  // DELETE: api/Task/5
  [HttpDelete("{id}")]
  public ActionResult Delete(int id)
  {
    TaskModel? taskToBeDeleted = _taskService.DeleteById(id);
    if (taskToBeDeleted is not null)
    {
      return Ok(taskToBeDeleted);
    }
    else
    {
      return NotFound();
    }
  }
}