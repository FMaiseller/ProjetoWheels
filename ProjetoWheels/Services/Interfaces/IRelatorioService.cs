using ProjetoWheels.Models;

namespace ProjetoWheels.Services.Interfaces
{
    public interface IRelatorioService
    {
        RelatorioViewModel GerarRelatorio(
            DateTime? dataInicio,
            DateTime? dataFim);
    }
}