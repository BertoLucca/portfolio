using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {

    }

    public DbSet<ToDoApp.Models.Task> ToDoTasks { get; set; } = null!;
}