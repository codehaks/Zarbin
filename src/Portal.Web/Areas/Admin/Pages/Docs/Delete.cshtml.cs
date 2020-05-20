using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Persistence;

namespace Portal.Web.Areas.Admin.Pages.Docs
{
    public class DeleteModel : PageModel
    {
        private readonly PortalDbContext _context;

        public DeleteModel(PortalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doc Doc { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doc = await _context.Docs.FirstOrDefaultAsync(m => m.Id == id);

            if (Doc == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doc = await _context.Docs.FindAsync(id);

            if (Doc != null)
            {
                _context.Docs.Remove(Doc);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
