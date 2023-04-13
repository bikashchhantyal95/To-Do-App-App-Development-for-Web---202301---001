using Microsoft.EntityFrameworkCore;
using Todo_App_WEB_1001.Models;

namespace Todo_App_WEB_1001.Data;

public class TodoContext: DbContext
{
 public TodoContext(DbContextOptions<TodoContext> options) : base(options)
 {
 }

 public DbSet<Todo> Todos => Set<Todo>();

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
  modelBuilder.Entity<Todo>().HasData(new Todo {Id = 1, Description = "Test1", Completed = false});
  modelBuilder.Entity<Todo>().HasData(new Todo { Id = 2, Description = "Test2", Completed = false});
 }
 
}