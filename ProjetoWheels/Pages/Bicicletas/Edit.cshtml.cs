using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoWheels.Data;
using ProjetoWheels.Models;

namespace ProjetoWheels.Pages.Bicicletas
{
    public class EditModel : PageModel
    {

        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bicicleta).State = EntityState.Modified;

            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}