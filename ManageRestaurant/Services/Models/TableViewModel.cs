using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class TableViewModel
    {
        public int TableID { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }
    }
}