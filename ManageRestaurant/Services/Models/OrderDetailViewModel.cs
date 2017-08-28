using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class OrderDetailViewModel
    {
        public int OrderDetailID { get; set; }
        public int Number { get; set; }
        public decimal Prices { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }

    }
}