namespace ToDoApp.Models;

public class CreateTaskDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}