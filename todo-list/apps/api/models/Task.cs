namespace ToDoApp.Models;

public class ToDoTask
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreateAt { get; set; }
}