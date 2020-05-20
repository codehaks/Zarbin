using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{
    public class WebPage
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public bool Hidden { get; set; }

        public PanelMode PanelMode { get; set; }
        public PanelType PanelType { get; set; }
    }

    public enum PanelMode
    {
        System = 0,
        User = 1

    }

    public enum PanelType
    {
        Partial = 0,
        Page = 1
    }
}
