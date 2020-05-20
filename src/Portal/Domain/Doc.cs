using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Entities
{
    public class Doc
    {
        private Doc()
        {

        }

        public Doc(Guid id, DocType docType=DocType.Upload)
        {
            DocType = docType;
            Id = id;
        }
        public Guid Id { get;private set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Extention { get; set; }
        public byte[] Data { get; set; }

        public DocType DocType { get; private set; }

    }

    public enum DocType
    {
        Upload=0,
        Product=1
    }
}
