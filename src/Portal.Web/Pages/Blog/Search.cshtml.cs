using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Pages.Blog
{
    public class SearchModel : PageModel
    {
        [BindProperty]
        public string Term { get; set; }

        public IList<Post> Output { get; set; }

        public void OnGet([FromServices]PortalDbContext db, string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                Term = term;
                Output = db.Posts.Where(p => p.Name.ToLower().Contains(term.ToLower()) || p.Body.Contains(term)).ToList();
            }
            else
            {
                Output=new List<Post>();
            }
            
        }
    }
}