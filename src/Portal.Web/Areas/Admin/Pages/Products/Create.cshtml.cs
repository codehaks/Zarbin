using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.Application.Docs;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Areas.Admin.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly PortalDbContext _context;
        private readonly IDocService _docService;

        public CreateModel(PortalDbContext context, IDocService docService)
        {
            _context = context;
            _docService = docService;

        }

        public IActionResult OnGet()
        {
            var categories = _context.Categories.Where(c=>c.ParentId==null).ToList();

            CategorySelectList = new SelectList(categories, "Id", "Name");
            return Page();
        }

        public SelectList CategorySelectList { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }


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

                var docId = Guid.NewGuid();

                await _docService.Create(new Application.Docs.Models.DocInfo
                {
                    Id = docId,
                    DocType=Domain.Entities.DocType.Product,
                    ContentType = ImageFile.ContentType,
                    FileName = ImageFile.FileName,
                    Extention = new FileInfo(ImageFile.FileName).Extension,
                    Data = ms1.ToArray()
                });


                Product.DocId = docId;
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
