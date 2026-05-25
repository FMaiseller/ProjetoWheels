using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public int TotalClientes { get; set; }

        public int BikesDisponiveis { get; set; }

        public int LocacoesAtivas { get; set; }

        public decimal ReceitaTotal { get; set; }

        public void OnGet()
        {
            TotalClientes =
                _context.Clientes.Count();

            BikesDisponiveis =
                _context.Bicicletas.Count(b =>
                    b.Status ==
                    StatusBicicleta.Disponivel);

            LocacoesAtivas =
                _context.Locacoes.Count(l =>
                    l.DataDevolucao == null);

            ReceitaTotal =
                _context.Locacoes
                    .ToList()
                    .Sum(l => l.ValorTotal + l.TaxaAtraso);
        }
    }
}
