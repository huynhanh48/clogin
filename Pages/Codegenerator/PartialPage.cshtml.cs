using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Login.Pages
{
    public class PartialPageModel : PageModel
    {
        protected readonly Login.LoginContext context;
        public PartialPageModel(LoginContext _context)
        {
            context =_context;
        }
        public void OnGet()
        {
            var GetContext = (from a in context.Cruds
            select a).ToList();
            ViewData["GetContext"] = GetContext;
        }
    }
}
