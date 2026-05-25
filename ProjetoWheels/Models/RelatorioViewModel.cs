namespace ProjetoWheels.Models;

public class RelatorioViewModel
{
    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public decimal ReceitaTotal { get; set; }

    public int TotalLocacoes { get; set; }

    public int BicicletasDisponiveis { get; set; }

    public int BicicletasAlugadas { get; set; }

    public string ClienteMaisLocacoes { get; set; } = "";

    public string BicicletaMaisAlugada { get; set; } = "";
}