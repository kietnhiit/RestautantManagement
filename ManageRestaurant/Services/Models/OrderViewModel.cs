using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public DateTime ExportDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Type { get; set; }
        public int? TableID { get; set; }

    }
}