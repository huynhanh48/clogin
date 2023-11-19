using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Login;
using Login.Model;

namespace Login.Pages_Blog
{
    public class DetailsModel : PageModel
    {
        private readonly Login.LoginContext _context;

        public DetailsModel(Login.LoginContext context)
        {
            _context = context;
        }

      public Crud Crud { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cruds == null)
            {
                return NotFound();
            }

            var crud = await _context.Cruds.FirstOrDefaultAsync(m => m.IDCrud == id);
            if (crud == null)
            {
                return NotFound();
            }
            else 
            {
                Crud = crud;
            }
            return Page();
        }
    }
}
