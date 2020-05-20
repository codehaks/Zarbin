using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Areas.Admin.Pages.Categories
{
    public class SubsModel : PageModel
    {
        
        private readonly PortalDbContext _db;

        public SubsModel(PortalDbContext db)
        {
            _db = db;
        }

        public IList<Category> CategoryList { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }

        public IList<Category> Parents { get; set; }

        public IActionResult OnGet(int parentId=0)
        {
            if (parentId==0)
            {
                return RedirectToPage("./index");
            }
            ParentId = parentId;
            Parents = new List<Category>();

            var catList = _db.Categories.ToList();

            var parentCat = catList.FirstOrDefault(c => c.Id == parentId);
            
            int level = 1;
            while (parentCat!=null)
            {
                Parents.Add(parentCat);

                parentCat = catList.FirstOrDefault(c => c.Id == parentCat.ParentId);
                level++;
            }

            Level = level;

            CategoryList = _db.Categories
                .Where(c => c.ParentId == parentId)
                .ToList();

            return Page();
        }
    }
}