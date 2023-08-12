using Task.Models;
using Task.Data;
using Microsoft.EntityFrameworkCore;
namespace Task.Services;

public class TaskService
{

  private readonly TaskContext _context;
  public TaskService(TaskContext taskContext)
  {
    _context = taskContext;
  }

  public IEnumerable<TaskModel> GetAll()
  {
    return _context.Tasks
     .AsNoTracking()
     .ToList();
  }

  public TaskModel? GetById(int id)
  {
    return _context.Tasks // Get the tasks table
     .AsNoTracking() // Do not track changes on this query
     .SingleOrDefault(p => p.Id == id); // Find the task by id
  }

  public TaskModel Create(TaskModel newTask)
  {
    // Add the task to the database
    _context.Tasks.Add(newTask);

    // Save changes on database
    _context.SaveChanges();

    // Return the task
    return newTask;
  }

  public TaskModel? UpdateStatus(int id, string status)
  {
    // Find the task by id
    TaskModel? taskToUpdate = _context.Tasks.Find(id);

    // Check if the task exists
    if (taskToUpdate is not null)
    {
      // Update the task status
      taskToUpdate.Status = status;

      // Update the task on database
      _context.Tasks.Update(taskToUpdate);

      // Save changes
      _context.SaveChanges();
    }

    // Return the task
    return taskToUpdate;
  }

  public TaskModel? Update(int id, TaskModel task)
  {
    // The Entity Framework context instance (_context) is used to set the task entity state to modified (EntityState.Modified).
    // This tells the Entity Framework that the entity has been modified and needs to be updated in the database.
    _context.Entry(task).State = EntityState.Modified;

    try
    {
      // Update the task on database
      _context.SaveChanges();

      // Return the task
      return task;
    }
    catch (DbUpdateConcurrencyException)
    {
      // If the task was not updated, return null
      return null;
    }
  }

  public TaskModel? DeleteById(int id)
  {
    // Find the task by id
    TaskModel? taskToDelete = _context.Tasks.Find(id);

    // Check if the task exists
    if (taskToDelete is not null)
    {

      // Delete the task
      _context.Tasks.Remove(taskToDelete);

      // Apply changes
      _context.SaveChanges();
    }

    // Return the task
    return taskToDelete;
  }
}