using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Login;
using Login.Model;

namespace Login.Pages_Blog
{
    public class CreateModel : PageModel
    {
        private readonly Login.LoginContext _context;

        public CreateModel(Login.LoginContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Crud Crud { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cruds == null || Crud == null)
            {
                return Page();
            }

            _context.Cruds.Add(Crud);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
