using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectAgroDeals.Models
{
    [Table("Units")]
    public class Units
    {
        [Key]
        public int UnitID { get; set; }
        public string UnitType { get; set; }
    }
}