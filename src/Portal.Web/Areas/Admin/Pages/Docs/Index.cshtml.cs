using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Persistence;

namespace Portal.Web.Areas.Admin.Pages.Docs
{
    public class IndexModel : PageModel
    {
        private readonly PortalDbContext _context;

        public IndexModel(PortalDbContext context)
        {
            _context = context;
        }

        public IList<Doc> Doc { get;set; }

        public async Task OnGetAsync()
        {
            Doc = await _context.Docs.Where(d=>d.DocType==DocType.Upload).ToListAsync();
        }
        
        
    }
}
