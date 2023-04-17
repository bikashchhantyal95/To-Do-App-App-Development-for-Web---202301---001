using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Todo_App_WEB_1001.Data;
using Todo_App_WEB_1001.Models;

namespace Todo_App_WEB_1001.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly TodoContext _todoContext; //database context
    public HomeController(ILogger<HomeController> logger, TodoContext todoContext)
    {
        _todoContext = todoContext;
        _logger = logger;
    }

    // index action method that retrieves all todo item from the database
    // and sends it to the index view
    public IActionResult Index()
    {
        // get data from todo table.
        // filter table to get todo whose completed value is false
        // List<Todo> todos = _todoContext.Todos.Where(todo => todo.Completed == false).ToList();
        
        //get all todos from database
        List<Todo> todos = _todoContext.Todos.ToList();
        
        // Send todos list to view
        ViewBag.Todos = todos;
        return View();
    }

    // privacy action method that return privacy view
    public IActionResult Privacy()
    {
        return View();
    }

    //create action method that return create view
    public IActionResult Create()
    {
        return View();
    }
    
    // POST: Todo/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // Create action method to add todo item to the database
    // and redirect to the index view
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Description,Completed,CompletionDate")] Todo todo)
    {
        if (ModelState.IsValid)
        {
            //add new todo to the database
            _todoContext.Add(todo);
            await _todoContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(todo);
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // MarkTodo action method to update the completed status of todo item
    // and redirects to the Index view
    [HttpPost]
    public async Task<IActionResult> MarkTodo(int? id)
    {
        // get todo with the id provided
        var todo = await _todoContext.Todos.FindAsync(id);
        
        // if todo is null return NotFound
        if (todo == null)
        {
            return NotFound();
        }

        //if todo is not null
        // set completed status of todo to true
        todo.Completed = true;
        
        // set the completionDate property of todo to the time the completed status was updated
        todo.CompletionDate = DateTime.Now;
        
        // update the todo
        _todoContext.Update(todo);
        
        // save the todo to database
        await _todoContext.SaveChangesAsync();
        
        // redirect to the Index page
        return RedirectToAction(nameof(Index));
    }

 
}