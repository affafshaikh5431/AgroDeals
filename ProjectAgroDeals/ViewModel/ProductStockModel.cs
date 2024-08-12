using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAgroDeals.ViewModel
{
    public class ProductStockModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public int CurrentStock { get; set; }
    }
}