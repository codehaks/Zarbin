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
    public class DetailsModel : PageModel
    {
        private readonly PortalDbContext _db;

        public DetailsModel(PortalDbContext db)
        {
            _db = db;
        }

        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _db.Products.Find(id);
        }
    }
}