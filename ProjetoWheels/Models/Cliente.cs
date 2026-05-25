using System.ComponentModel.DataAnnotations;

namespace ProjetoWheels.Models;

public class Cliente
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } 

    [Required]
    [StringLength(11)]
    public string CPF { get; set; } 

    [Phone]
    public string Telefone { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}