using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        
    }
}
