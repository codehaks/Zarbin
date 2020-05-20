using Portal.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Modules.Settings
{
    public class OptionHistory:ITimeCreated
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime TimeCreated { get; set; }
    }

   
}
