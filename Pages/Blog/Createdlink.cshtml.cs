using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Login.Model;

namespace Login.Pages_Blog
{
    public class CreatedlinkModel : PageModel
    {
        protected readonly LoginContext context;
        public  CreatedlinkModel(Login.LoginContext _context)
        {
            context = _context;
        }
        [BindProperty]
        public Crud cruds{get;set;} = default!;
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid || cruds ==null)
            {
                return Page();
            }
            await context.Cruds.AddAsync(cruds);
            await context.SaveChangesAsync();
            return  RedirectToPage("/Index");
        }
    }
}
