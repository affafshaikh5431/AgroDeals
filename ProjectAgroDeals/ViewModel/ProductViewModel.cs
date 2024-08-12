using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProjectAgroDeals.Models;

namespace ProjectAgroDeals.ViewModel
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        public int UserID { get; set; }



       [Display(Name = "Product Name")]
       public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }


        public string ProductPicture { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Category")]
        public string CatName { get; set; }

        [Display(Name = "Unit Size")]
        public string UnitType { get; set; }

        public int CatID { get; set; }

    }
}