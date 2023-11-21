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
        public void OnGet(string ?id)
        {
            var GetContext = (from a in context.Cruds
            select a).ToList();
            ViewData["GetContext"] = GetContext;
            if(!string.IsNullOrEmpty(id))
            {
                var convert = int.Parse(id);
                var linq = (from a in context.Cruds
                where  a.IDCrud == convert
                select a).ToList();
                ViewData["GetContext2"] = linq;
                
            }
        }
    }
}
