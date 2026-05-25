using System.ComponentModel.DataAnnotations;

namespace ProjetoWheels.Models;

public class Bicicleta
{
    public int Id { get; set; }

    [Required]
    public string Marca { get; set; } 

    [Required]
    public string Tipo { get; set; } 

    public string Tamanho { get; set; } = string.Empty;

    [Range(0, 999)]
    [Display(Name = "Valor da Diária")]
    public decimal ValorDiaria { get; set; } = 0;

    public StatusBicicleta Status { get; set; } = StatusBicicleta.Disponivel;

}