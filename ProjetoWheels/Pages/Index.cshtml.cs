using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoWheels.Data;
using ProjetoWheels.Models;
using ProjetoWheels.Services;

namespace ProjetoWheels.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDashBoardService _dashboardService;

        public IndexModel(IDashBoardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public int TotalClientes { get; set; }

        public int BikesDisponiveis { get; set; }

        public int LocacoesAtivas { get; set; }

        public decimal ReceitaTotal { get; set; }

        public void OnGet()
        {
            TotalClientes = _dashboardService.TotalClientes();
            BikesDisponiveis = _dashboardService.BikesDisponiveis();
            LocacoesAtivas = _dashboardService.LocacoesAtivas();
            ReceitaTotal = _dashboardService.ReceitaTotal();
        }
    }
}