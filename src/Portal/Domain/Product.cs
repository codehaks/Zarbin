using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }


        [Display(Name="نام")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }

        public int Rating { get; set; }

        [Display(Name = "فعال")]
        public bool Active { get; set; }

        public Guid DocId { get; set; }


    }
}
