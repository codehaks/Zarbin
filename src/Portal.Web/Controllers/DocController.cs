using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Docs;
using Portal.Common.Extentions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Portal.Web.Controllers
{
    public class DocController : Controller
    {
        private readonly IDocService _docService;
        public DocController(IDocService docService)
        {
            _docService = docService;
        }

        [Route("docs/file/{docid}/{name?}")]
        public IActionResult GetFile(Guid docId)
        {
            var doc = _docService.GetById(docId);
            if (doc == null)
            {
                return NotFound();
            }


            return File(doc.Data, doc.ContentType);
        }

        [Route("docs/file/{docid}/{width}x{height}")]
        public IActionResult GetImage(Guid docId, int width = 300, int height = 300)
        {
            var doc = _docService.GetById(docId);
            if (doc==null)
            {
                return NotFound();
            }

            Stream imageStream = new MemoryStream();

            using (Image<Rgba32> image = Image.Load( doc.Data))
            {
                image.Mutate(x => x
                     .Resize(width, height));
                image.SaveAsJpeg(imageStream);
            }

            imageStream.Position = 0;


            return File(imageStream, doc.ContentType);
        }
    }
}