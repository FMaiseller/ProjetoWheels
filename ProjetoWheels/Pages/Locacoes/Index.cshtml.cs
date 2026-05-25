using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages.Locacoes
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Locacao> Locacoes { get; set; } = new();

        public void OnGet()
        {
            Locacoes = _context.Locacoes.Include(l => l.Cliente).Include(l => l.Bicicleta).ToList();
        }
    }
}