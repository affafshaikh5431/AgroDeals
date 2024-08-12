using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectAgroDeals.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int CatID { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public DateTime Dated { get; set; }
        public string Status { get; set; }
        
        [ForeignKey("CatID")]
        public virtual Categories Categories { get; set; }

        

        [ForeignKey("ProductID")]
        public virtual Products Products { get; set; }
    }
}