namespace ToDoApp.Models;

public class GetManyTaskDTO
{
    public string? Name { get; set; }
    public bool? IsCompleted { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class GetOneTaskDTO : GetManyTaskDTO
{
    public int? Id { get; set; }

}