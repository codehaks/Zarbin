using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.Docs.Models
{
    public class DocInfo
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Extention { get; set; }
        public byte[] Data { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DocType DocType { get; set; }

    }
}
