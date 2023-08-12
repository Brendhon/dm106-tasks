namespace Task.Models;

public class TaskModel
{
  public int Id { get; set; } // Primary Key | Get and Set (Read and Write)
  public string? Name { get; set; } // Task Name | Get and Set (Read and Write)
  public string? Category { get; set; } // Task Category | Get and Set (Read and Write)
  public string? Status { get; set; } // Task Status | Get and Set (Read and Write)
  public int Priority { get; set; } // Task Priority | Get and Set (Read and Write)
}