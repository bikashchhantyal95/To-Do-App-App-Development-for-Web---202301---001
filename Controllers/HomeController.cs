using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Todo_App_WEB_1001.Data;
using Todo_App_WEB_1001.Models;

namespace Todo_App_WEB_1001.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly TodoContext _todoContext;
    public HomeController(ILogger<HomeController> logger, TodoContext todoContext)
    {
        _todoContext = todoContext;
        _logger = logger;
    }

    public IActionResult Index()
    {
        // get data from todo table.
        // filter table to get todo whose completed value is false
        List<Todo> todos = _todoContext.Todos.Where(todo => todo.Completed == false).ToList();
        // Send todos list to view
        ViewBag.Todos = todos;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
    // POST: Todo/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Description,Completed,CompltedDate")] Todo todo)
    {
        if (ModelState.IsValid)
        {
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
}