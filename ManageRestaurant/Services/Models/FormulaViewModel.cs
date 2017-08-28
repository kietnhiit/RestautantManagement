using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class FormulaViewModel
    {
        [Required]
        public int ProductParentID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public decimal Number { get; set; }
    }
}