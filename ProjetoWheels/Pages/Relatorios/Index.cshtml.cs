using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages.Relatorios
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public RelatorioViewModel Relatorio { get; set; } = new();

        public void OnGet(DateTime? dataInicio, DateTime? dataFim)
        {
            Relatorio.DataInicio = dataInicio;
            Relatorio.DataFim = dataFim;

            var locacoes = _context.Locacoes.AsQueryable();

            if (dataInicio.HasValue)
            {
                locacoes = locacoes.Where(l =>
                    l.DataInicio >= dataInicio.Value);
            }

            if (dataFim.HasValue)
            {
                locacoes = locacoes.Where(l =>
                    l.DataInicio < dataFim.Value.AddDays(1));
            }

            var listaLocacoes = locacoes.ToList();

            Relatorio.ReceitaTotal =
                locacoes
                    .ToList()
                    .Sum(l => l.ValorTotal + l.TaxaAtraso);

            Relatorio.TotalLocacoes =
                locacoes.Count();

            Relatorio.BicicletasDisponiveis =
                _context.Bicicletas
                    .Count(b => b.Status ==
                        StatusBicicleta.Disponivel);

            Relatorio.BicicletasAlugadas =
                _context.Bicicletas
                    .Count(b => b.Status ==
                        StatusBicicleta.Alugada);

            var clienteMaisLocacoes =
                locacoes
                    .GroupBy(l => l.Cliente.Nome)
                    .Select(g => new
                    {
                        Nome = g.Key,
                        Total = g.Count()
                    })
                    .OrderByDescending(g => g.Total)
                    .FirstOrDefault();

            if (clienteMaisLocacoes != null)
            {
                Relatorio.ClienteMaisLocacoes =
                    clienteMaisLocacoes.Nome;
            }

            var bicicletaMaisAlugada =
                locacoes
                    .GroupBy(l => l.Bicicleta.Marca)
                    .Select(g => new
                    {
                        Marca = g.Key,
                        Total = g.Count()
                    })
                    .OrderByDescending(g => g.Total)
                    .FirstOrDefault();

            if (bicicletaMaisAlugada != null)
            {
                Relatorio.BicicletaMaisAlugada =
                    bicicletaMaisAlugada.Marca;
            }
        }
    }
}