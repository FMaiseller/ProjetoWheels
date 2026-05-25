using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages.Bicicletas
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bicicleta Bicicleta { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var bicicleta = _context.Bicicletas.Find(id);

            if (bicicleta == null)
            {
                return NotFound();
            }

            Bicicleta = bicicleta;

            return Page();
        }

        public IActionResult OnPost()
        {
            var bicicleta = _context.Bicicletas.Find(Bicicleta.Id);

            if (Bicicleta.Status == StatusBicicleta.Alugada)
            {
                return RedirectToPage("Index");
            }

            if (bicicleta != null)
            {
                _context.Bicicletas.Remove(bicicleta);

                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}