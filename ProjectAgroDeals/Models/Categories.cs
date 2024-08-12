using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectAgroDeals.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int CatID { get; set; }
        public string CatName { get; set; }
    }
    
}