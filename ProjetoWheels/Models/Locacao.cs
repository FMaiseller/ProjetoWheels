using System.ComponentModel.DataAnnotations;

namespace ProjetoWheels.Models;

public class Locacao
{

    public int Id { get; set; }

    [Required]
    [Display(Name = "Cliente")]
    public int ClienteId { get; set; }

    public Cliente? Cliente { get; set; }

    [Required]
    [Display(Name = "Bicicleta")]
    public int BicicletaId { get; set; }

    public Bicicleta? Bicicleta { get; set; } 

    [Display(Name = "Data Início")]
    public DateTime DataInicio { get; set; } =
        DateTime.Now;

    [Display(Name = "Data Final")]
    public DateTime DataFimPrevista { get; set; }

    [Display(Name = "Data Devolução")]
    public DateTime? DataDevolucao { get; set; }

    [Display(Name = "Valor Total")]
    public decimal ValorTotal { get; set; }

    [Display(Name = "Depósito Pago")]
    public decimal DepositoPago { get; set; }

    [Display(Name = "Taxa de Atraso")]
    public decimal TaxaAtraso { get; set; }
}
