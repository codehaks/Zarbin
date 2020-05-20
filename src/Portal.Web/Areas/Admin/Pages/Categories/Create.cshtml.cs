using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Areas.Admin.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Portal.Persistence.PortalDbContext _context;

        public CreateModel(Portal.Persistence.PortalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int? ParentId { get; set; }

        public IActionResult OnGet(int? parentId)
        {
            ParentId = parentId;
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ParentId!=null)
            {
                Category.ParentId = ParentId.Value;
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}