using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages.Locacoes
{
    public class DevolverModel : PageModel
    {
        private readonly AppDbContext _context;

        public DevolverModel(AppDbContext context)
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
                .Include(l => l.Bicicleta)
                .FirstOrDefault(l => l.Id == Locacao.Id);

            if (locacao == null)
            {
                return NotFound();
            }

            locacao.DataDevolucao = DateTime.Now;

            int diasAtraso =
                (locacao.DataDevolucao.Value -
                 locacao.DataFimPrevista).Days;

            if (diasAtraso > 0)
            {
                locacao.TaxaAtraso =
                    diasAtraso *
                    locacao.Bicicleta.ValorDiaria;
            }

            locacao.Bicicleta.Status =
                StatusBicicleta.Disponivel;

            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}