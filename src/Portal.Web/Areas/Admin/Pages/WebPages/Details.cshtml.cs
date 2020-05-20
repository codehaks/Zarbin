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
    public class DetailsModel : PageModel
    {
        private readonly Portal.Persistence.PortalDbContext _context;

        public DetailsModel(Portal.Persistence.PortalDbContext context)
        {
            _context = context;
        }

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
    }
}
