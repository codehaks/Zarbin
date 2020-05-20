using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Areas.Admin.Pages.WebPages
{
    public class DeleteModel : PageModel
    {
        private readonly Portal.Persistence.PortalDbContext _context;

        public DeleteModel(Portal.Persistence.PortalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WebPage Panel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Panel = await _context.WebPages.FirstOrDefaultAsync(m => m.Name == id);

            if (Panel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Panel = await _context.WebPages.FindAsync(id);

            if (Panel != null)
            {
                _context.WebPages.Remove(Panel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
