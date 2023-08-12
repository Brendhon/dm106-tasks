using System.ComponentModel.DataAnnotations;

namespace Task.Models;

public class TaskModel
{
  public int Id { get; set; } // Primary Key | Get and Set (Read and Write)

  [Required]
  [StringLength(20, ErrorMessage = "O tamanho máximo do nome é 20 caracteres")]
  public string? Name { get; set; }

  [Required]
  [StringLength(20, ErrorMessage = "O tamanho máximo da categoria é 10 caracteres")]
  public string? Category { get; set; }

  [Required]
  [StringLength(20, ErrorMessage = "O tamanho máximo do status é 10 caracteres")]
  public string? Status { get; set; }

  [Range(0, 5, ErrorMessage = "A prioridade deve ser entre 0 e 5")]
  public int priority { get; set; }
}