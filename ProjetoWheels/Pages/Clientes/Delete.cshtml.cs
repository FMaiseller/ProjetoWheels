using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages.Clientes;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
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
        var cliente = _context.Clientes.Find(Cliente.Id);

        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);

            _context.SaveChanges();
        }

        return RedirectToPage("Index");
    }
}
