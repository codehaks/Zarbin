using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Areas.Admin.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly PortalDbContext _context;

        public EditModel(PortalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ImageFile != null)
            {
                using var ms1 = new MemoryStream();
                ImageFile.CopyTo(ms1);
                ms1.Position = 0;


            }

            var oldProduct = _context.Products.Find(Product.Id);
            oldProduct.Name = Product.Name;
            oldProduct.Active = Product.Active;
            oldProduct.Description = Product.Description;
            oldProduct.Price = Product.Price;
            oldProduct.Rating = Product.Rating;
            
            _context.Entry(oldProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
