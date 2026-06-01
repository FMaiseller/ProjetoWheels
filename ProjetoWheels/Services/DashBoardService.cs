using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Services
{
    public class DashBoardService : IDashBoardService
    {
        private readonly AppDbContext _context;
        public DashBoardService(AppDbContext context)
        {
            _context = context;
        }
        public int TotalClientes()
        {
            return _context.Clientes.Count();
        }
        public int BikesDisponiveis()
        {
            return _context.Bicicletas.Count(b =>
                b.Status ==
                StatusBicicleta.Disponivel);
        }
        public int LocacoesAtivas()
        {
            return _context.Locacoes.Count(l =>
                 l.DataDevolucao == null);
        }
        public decimal ReceitaTotal()
        {
            return _context.Locacoes
                .ToList()
                .Sum(l => l.ValorTotal + l.TaxaAtraso);
        }
    }
}