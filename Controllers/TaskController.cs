using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
  // 
  private readonly ILogger<TaskController> _logger;

  public TaskController(ILogger<TaskController> logger)
  {
    _logger = logger;
  }

  // GET: api/Task
  [HttpGet]
  public string GetAll()
  {
    _logger.LogInformation("Get all logs");
    return "All tasks";
  }
}