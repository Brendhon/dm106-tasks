using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Data;

public class TaskContext : DbContext
{
  public TaskContext(DbContextOptions<TaskContext> options) : base(options)
  {
  }

  // Set database table from TaskModel
  public DbSet<TaskModel> Tasks => Set<TaskModel>();
}