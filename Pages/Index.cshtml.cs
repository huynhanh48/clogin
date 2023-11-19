using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Login.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly LoginContext context;

    public IndexModel(ILogger<IndexModel> logger, LoginContext _context)
    {
        _logger = logger;
        context =_context;
    }

    public void OnGet()
    {
        var baiviet = (from i in context.Cruds
        select i).ToList();
        ViewData["post"] = baiviet;
    }
}
