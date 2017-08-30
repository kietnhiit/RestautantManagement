using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class TypeOfEmployeeViewModel
    {
        public int TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string NameOfType { get; set; }
    }
}