using ProjetoWheels.Data;
using ProjetoWheels.Models;
using ProjetoWheels.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProjetoWheels.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly AppDbContext _context;

        public RelatorioService(AppDbContext context)
        {
            _context = context;
        }

        public RelatorioViewModel GerarRelatorio(
            DateTime? dataInicio,
            DateTime? dataFim)
        {
            var relatorio = new RelatorioViewModel
            {
                DataInicio = dataInicio,
                DataFim = dataFim
            };

            var locacoes = _context.Locacoes
            .Include(l => l.Cliente)
            .Include(l => l.Bicicleta)
            .AsQueryable();

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

            relatorio.ReceitaTotal =
                listaLocacoes.Sum(l =>
                    l.ValorTotal + l.TaxaAtraso);

            relatorio.TotalLocacoes =
                listaLocacoes.Count;

            relatorio.BicicletasDisponiveis =
                _context.Bicicletas.Count(b =>
                    b.Status == StatusBicicleta.Disponivel);

            relatorio.BicicletasAlugadas =
                _context.Bicicletas.Count(b =>
                    b.Status == StatusBicicleta.Alugada);

            var clienteMaisLocacoes =
                listaLocacoes
                    .GroupBy(l => l.Cliente.Nome)
                    .Select(g => new
                    {
                        Nome = g.Key,
                        Total = g.Count()
                    })
                    .OrderByDescending(g => g.Total)
                    .FirstOrDefault();

            relatorio.ClienteMaisLocacoes =
                clienteMaisLocacoes?.Nome;

            var bicicletaMaisAlugada =
                listaLocacoes
                    .GroupBy(l => l.Bicicleta.Marca)
                    .Select(g => new
                    {
                        Marca = g.Key,
                        Total = g.Count()
                    })
                    .OrderByDescending(g => g.Total)
                    .FirstOrDefault();

            relatorio.BicicletaMaisAlugada =
                bicicletaMaisAlugada?.Marca;

            relatorio.TotalClientes =
                _context.Clientes.Count();

            return relatorio;
        }
    }
}