using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Domain
{
    public class Post
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Display(Name = "عنوان")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Display(Name = "خلاصه")]
        public string Summary { get; set; }

        [Display(Name = "عکس تیتر")]
        public string ImageUrl { get; set; }

        [MaxLength(10000)]
        [Display(Name = "متن")]
        public string Body { get; set; }

        [MaxLength(50)]
        [Display(Name = "تگها")]
        public string Tags { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime TimeCreated { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int Hits { get; set; }

        [Display(Name = "منتشر شده")]
        public bool IsPublished { get; set; }
    }
}
