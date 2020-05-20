using Portal.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{
    public class Menu : ITimeCreated
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public bool IsPublished { get; set; }
        public bool HideSubs { get; set; }

        public int ParentId { get; set; }
        public MenuType MenuType { get; set; }
        public TargetType TargetType { get; set; }

        public DateTime TimeCreated { get; set; }
    }

    public enum MenuType
    {
        Root = 0,
        Branch = 1,
        Node = 2
    }

    public enum TargetType
    {
        None = 0,
        InternalLink = 1,
        ExternalLink = 2
    }
}
