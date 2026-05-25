using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages.Clientes;

public class IndexModel : PageModel
{
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Cliente> Clientes { get; set; } = new List<Cliente>();

        public void OnGet ()
        {
            Clientes = _context.Clientes.ToList();
        }
    }

