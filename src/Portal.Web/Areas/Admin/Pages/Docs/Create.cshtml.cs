using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.Domain.Entities;
using Portal.Persistence;

namespace Portal.Web.Areas.Admin.Pages.Docs
{
    public class CreateModel : PageModel
    {
        private readonly PortalDbContext _context;

        public CreateModel(PortalDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [MaxLength(20,ErrorMessage ="نام می تواند حداکثر 20 حرف باشد")]
        [Display(Name ="نام")]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "توضیحات می تواند حداکثر 250 حرف باشد")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }


  

        [BindProperty]
        public IFormFile ImageFile { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var doc = new Doc(Guid.NewGuid());


            if (ImageFile != null)
            {
                using var ms1 = new MemoryStream();
                ImageFile.CopyTo(ms1);
                ms1.Position = 0;

                if (string.IsNullOrEmpty(doc.Name))
                {
                    doc.Name = ImageFile.FileName;
                }

                doc.Data = ms1.ToArray();
                doc.ContentType = ImageFile.ContentType;
                doc.FileName = ImageFile.FileName;
            }

            _context.Docs.Add(doc);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
