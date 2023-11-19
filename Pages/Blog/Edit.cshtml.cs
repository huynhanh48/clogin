using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Login;
using Login.Model;

namespace Login.Pages_Blog
{
    public class EditModel : PageModel
    {
        private readonly Login.LoginContext _context;

        public EditModel(Login.LoginContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Crud Crud { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cruds == null)
            {
                return NotFound();
            }

            var crud =  await _context.Cruds.FirstOrDefaultAsync(m => m.IDCrud == id);
            if (crud == null)
            {
                return NotFound();
            }
            Crud = crud;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Crud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrudExists(Crud.IDCrud))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CrudExists(int id)
        {
          return (_context.Cruds?.Any(e => e.IDCrud == id)).GetValueOrDefault();
        }
    }
}
