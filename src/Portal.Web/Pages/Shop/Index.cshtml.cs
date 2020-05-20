using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Pages.Shop
{
    public class IndexModel : PageModel
    {
        private readonly PortalDbContext _db;

        public IndexModel(PortalDbContext db)
        {
            _db = db;
        }

        public IList<Product> ProductList { get; set; }

        public void OnGet()
        {
            ProductList = _db.Products.ToList();

        }
    }
}