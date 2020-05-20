
using System;
using System.ComponentModel.DataAnnotations;
using Portal.Common.Extentions;
using System.ComponentModel.DataAnnotations.Schema;

using System.Globalization;
using Humanizer;

namespace Portal.Core.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        //[MaxLength(100)]
        public string Slug => Name.ToSlug();

        [MaxLength(500)]
        public string Summary { get; set; }

        [MaxLength(10000)]
        public string Body { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(50)]
        public string Tags { get; set; }

        public DateTime TimeCreated { get; set; }

        [NotMapped]
        public string TimeCreatedHumanized { get { return TimeCreated.Humanize(culture: new CultureInfo("fa-IR",false)); } }

        public int Hits { get; set; }

        public bool IsPublished { get; set; }
    }
}