using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProjectAgroDeals.Models;

namespace ProjectAgroDeals.ViewModel
{
    public class FavProduct
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int StockCount { get; set; }
        public int RepetitionCount { get; set; }

        [ForeignKey("ProductID")]
        public virtual Products Products { get; set; }

        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }

    }
}