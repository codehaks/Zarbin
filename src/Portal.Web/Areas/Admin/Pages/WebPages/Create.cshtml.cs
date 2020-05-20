using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Areas.Admin.Pages.WebPages
{
    public class CreateModel : PageModel
    {
        private readonly Portal.Persistence.PortalDbContext _context;

        public CreateModel(Portal.Persistence.PortalDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WebPage Panel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WebPages.Add(Panel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
