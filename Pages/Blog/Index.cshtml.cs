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
    public class IndexModel : PageModel
    {
        private readonly Login.LoginContext _context;

        public IndexModel(Login.LoginContext context)
        {
            _context = context;
        }

        public IList<Crud> Crud { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cruds != null)
            {
                Crud = await _context.Cruds.ToListAsync();
            }
        }
    }
}
