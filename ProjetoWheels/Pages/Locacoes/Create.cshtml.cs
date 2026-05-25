using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages.Locacoes;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Locacao Locacao { get; set; } = new();

    public SelectList Clientes { get; set; }

    public SelectList Bicicletas { get; set; }

    public void CarregarDados()
    {
        Clientes = new SelectList(
            _context.Clientes.ToList(),
            "Id",
            "Nome"
        );

        Bicicletas = new SelectList(
    _context.Bicicletas
        .Where(b => b.Status == StatusBicicleta.Disponivel)
        .Select(b => new
        {
            b.Id,
            Descricao =
                b.Id + " - " +
                b.Marca + " - " +
                b.Tipo + " - " +
                b.Tamanho
        })
        .ToList(),
    "Id",
    "Descricao"
        );
    }

    public IActionResult OnGet()
    {
        CarregarDados();

        return Page();
    }

    public IActionResult OnPost()
    {
        CarregarDados();

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var bicicleta =
            _context.Bicicletas.Find(Locacao.BicicletaId);

        if (bicicleta == null)
        {
            return Page();
        }

        int dias =
            (Locacao.DataFimPrevista - Locacao.DataInicio).Days;

        if (dias <= 0)
        {
            dias = 1;
        }

        Locacao.ValorTotal =
            dias * bicicleta.ValorDiaria;

        bicicleta.Status =
            StatusBicicleta.Alugada;

        _context.Locacoes.Add(Locacao);

        _context.SaveChanges();

        return RedirectToPage("Index");
    }
}