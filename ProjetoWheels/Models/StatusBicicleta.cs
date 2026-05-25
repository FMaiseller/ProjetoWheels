using System.ComponentModel.DataAnnotations;

namespace ProjetoWheels.Models;

public enum StatusBicicleta
{
    [Display(Name = "Disponível")]
    Disponivel,

    [Display(Name = "Alugada")]
    Alugada,

    [Display(Name = "Manutenção")]
    Manutencao
}