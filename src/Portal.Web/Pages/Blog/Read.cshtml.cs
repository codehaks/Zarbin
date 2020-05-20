using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Common.Extentions;
using Portal.Core.ViewModels;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Pages.Blog
{
    public class ReadModel : PageModel
    {
        public Post Output { get; set; }

        public void OnGet([FromServices] PortalDbContext db, int id, string slug)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["userName"] = User.Identity.Name.ExtractEmailAccount();
            }
            else
            {
                ViewData["userName"] = "";
            }

            ViewData["userAuth"] = User.Identity.IsAuthenticated;

            Output = db.Posts.Find(id);

        }
    }
}