using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectAgroDeals.Models
{
    
    [Table("Message")]
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

              public string MessageBody { get; set; }

        public DateTime Dated { get; set; }

    }
}