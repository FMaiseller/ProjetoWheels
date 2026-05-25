using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages.Locacoes
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Locacao Locacao { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var locacao = _context.Locacoes
                .Include(l => l.Cliente)
                .Include(l => l.Bicicleta)
                .FirstOrDefault(l => l.Id == id);

            if (locacao == null)
            {
                return NotFound();
            }

            Locacao = locacao;

            return Page();
        }

        public IActionResult OnPost()
        {
            var locacao = _context.Locacoes
                .FirstOrDefault(l => l.Id == Locacao.Id);

            if (locacao == null)
            {
                return NotFound();
            }

            locacao.DataFimPrevista =
                Locacao.DataFimPrevista;

            locacao.DepositoPago =
                Locacao.DepositoPago;

            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
