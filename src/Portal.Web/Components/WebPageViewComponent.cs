using Microsoft.AspNetCore.Mvc;
using Portal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.Components
{
    public class PanelViewComponent: ViewComponent
    {
        private readonly PortalDbContext _db;

        public PanelViewComponent(PortalDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            var model = await _db.WebPages.FindAsync(name);
          
            return View(model);
        }
    }
}
