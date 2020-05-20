using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Pages
{
    public class AboutModel : PageModel
    {
        public WebPage Panel { get; set; }
        public void OnGet([FromServices] PortalDbContext db)
        {
            Panel = db.WebPages.Find("About");
        }
    }
}