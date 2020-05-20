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
    public class IndexModel : PageModel
    {
        private readonly Portal.Persistence.PortalDbContext _context;

        public IndexModel(Portal.Persistence.PortalDbContext context)
        {
            _context = context;
        }

        public IList<WebPage> Panel { get;set; }

        public async Task OnGetAsync()
        {
            Panel = await _context.WebPages.ToListAsync();
        }
    }
}
