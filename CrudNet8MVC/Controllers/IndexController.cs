using System.Diagnostics;
using CrudNet8MVC.Data;
using Microsoft.AspNetCore.Mvc;
using CrudNet8MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8MVC.Controllers;

public class IndexController : Controller
{
    private readonly ApplicationDbContext _context;
    public IndexController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Contact.ToListAsync());
    }

    // Es la vista de la pagina para crear usuario, por eso es GET
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    // Es el formulario para crear el usuario
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            // Agregar fecha
            contact.FechaCreacion = DateTime.Now;
            
            _context.Contact.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    
    // Es la vista de la pagina para crear usuario, por eso es GET
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null) return NotFound();

        var contact = _context.Contact.Find(id);
        if (contact == null) return NotFound();
        
        return View(contact);
    }
    
    // Es el formulario para editar el usuario
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _context.Update(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    
    
    // Es la vista de la pagina para crear usuario, por eso es GET
    [HttpGet]
    public IActionResult Detail(int? id)
    {
        if (id == null) return NotFound();

        var contact = _context.Contact.Find(id);
        if (contact == null) return NotFound();
        
        return View(contact);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}