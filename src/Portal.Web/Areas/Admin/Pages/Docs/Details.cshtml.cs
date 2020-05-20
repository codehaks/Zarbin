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
    public class DetailsModel : PageModel
    {
        private readonly PortalDbContext _context;

        public DetailsModel(PortalDbContext context)
        {
            _context = context;
        }

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
    }
}
