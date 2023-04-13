using System.ComponentModel.DataAnnotations;

namespace Todo_App_WEB_1001.Models;

public class Todo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Description { get; set; } = String.Empty;

    public bool Completed { get; set; } = false;

    public DateTime? CompletionDate { get; set; }
}