namespace ProjetoWheels.Services
{
    public interface IDashBoardService
    {
        public int TotalClientes();
        public int BikesDisponiveis();
        public int LocacoesAtivas();
        public decimal ReceitaTotal();
    }
}