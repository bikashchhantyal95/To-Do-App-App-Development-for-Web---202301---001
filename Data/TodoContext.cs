using Microsoft.EntityFrameworkCore;
using Todo_App_WEB_1001.Models;

namespace Todo_App_WEB_1001.Data;

public class TodoContext: DbContext
{
 public TodoContext(DbContextOptions<TodoContext> options) : base(options)
 {
 }

 public DbSet<Todo> Todos => Set<Todo>();
}