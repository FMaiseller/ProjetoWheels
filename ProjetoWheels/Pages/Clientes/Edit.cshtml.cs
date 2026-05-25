using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages.Clientes;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Cliente Cliente { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var cliente = _context.Clientes.Find(id);

        if (cliente == null)
        {
            return NotFound();
        }

        Cliente = cliente;

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Cliente).State = EntityState.Modified;

        _context.SaveChanges();

        return RedirectToPage("Index");
    }
}
