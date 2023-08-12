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
    // Get all tasks
    return _taskService.GetAll();
  }

  // GET: api/Task/5
  [HttpGet("{id}")]
  public ActionResult<TaskModel> GetById(int id)
  {
    // Get the task by id
    TaskModel? task = _taskService.GetById(id);

    // Check if the task exists and return it
    if (task is not null) return Ok(task);

    // If the task does not exist, return not found
    return NotFound();
  }

  // POST: api/Task
  [HttpPost]
  public ActionResult Create(TaskModel newTask)
  {
    // Check if the model is valid
    if (!ModelState.IsValid) return BadRequest(ModelState);

    // Create the task
    TaskModel task = _taskService.Create(newTask);

    // Return the task
    return CreatedAtAction(nameof(GetById), new { id = task!.Id }, task);
  }

  // PUT: api/Task/5
  [HttpPut("{id}")]
  public ActionResult Update(int id, TaskModel task)
  {
    // Check if the model is valid
    if (!ModelState.IsValid) return BadRequest(ModelState);

    // Check if the id is the same
    if (id != task.Id) return BadRequest();

    // Update the task
    TaskModel? taskUpdated = _taskService.Update(id, task);

    // Check if the task was updated
    if (taskUpdated is not null) return Ok(taskUpdated);

    // If the task was not updated, return not found
    return NotFound();
  }

  // DELETE: api/Task/5
  [HttpDelete("{id}")]
  public ActionResult Delete(int id)
  {
    // Delete the task
    TaskModel? taskToBeDeleted = _taskService.DeleteById(id);

    // Check if the task was deleted
    if (taskToBeDeleted is not null) return Ok(taskToBeDeleted);

    // If the task was not deleted, return not found
    return NotFound();
  }
}