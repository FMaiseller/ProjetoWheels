using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoWheels.Models;
using ProjetoWheels.Services.Interfaces;

namespace ProjetoWheels.Pages.Relatorios
{
    public class IndexModel : PageModel
    {
        private readonly IRelatorioService _relatorioService;

        public IndexModel(
            IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        public RelatorioViewModel Relatorio { get; set; } = new();

        public void OnGet(
            DateTime? dataInicio,
            DateTime? dataFim)
        {
            Relatorio = _relatorioService
                .GerarRelatorio(dataInicio, dataFim);
        }
    }
}