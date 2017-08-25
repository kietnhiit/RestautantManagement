using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="Retype of Password")]
        public string RePassword { get; set; }
        [Display(Name = "First Name")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public bool Gender { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        public int TypeID { get; set; }
        [Display(Name = "Type")]
        public string TypeName { get; set; }
        
    }
}