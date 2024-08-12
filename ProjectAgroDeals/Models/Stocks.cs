using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectAgroDeals.Models
{
    public class Stocks
    {
        [Key]

        public int StockID { get; set; }

        public int ProductID { get; set; }

        public int InQty { get; set; }

        public int OutQty { get; set; }

        public int Total { get; set; }

        [ForeignKey("ProductID")]
        public virtual Products Products { get; set; }
    }
}