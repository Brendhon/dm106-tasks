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
    return _context.Tasks
     .AsNoTracking()
     .SingleOrDefault(p => p.Id == id);
  }

  public TaskModel Create(TaskModel newTask)
  {
    _context.Tasks.Add(newTask);
    _context.SaveChanges();
    return newTask;
  }

  public TaskModel? Update(int id, TaskModel task)
  {
    _context.Entry(task).State = EntityState.Modified;
    try
    {
      _context.SaveChanges();
      return task;
    }
    catch (DbUpdateConcurrencyException)
    {
      return null;
    }
  }

  public TaskModel? DeleteById(int id)
  {
    TaskModel? taskToDelete = _context.Tasks.Find(id);
    if (taskToDelete is not null)
    {

      _context.Tasks.Remove(taskToDelete);
      _context.SaveChanges();
    }
    return taskToDelete;
  }
}