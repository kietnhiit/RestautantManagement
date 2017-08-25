using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using Services.Models;
namespace Services.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeDAL eDAL;
        public EmployeeController()
        {
            eDAL = new EmployeeDAL();
        }
        public IHttpActionResult GetAllEmployee()
        {
            var lst = eDAL.GetAllEmployee();
            if (lst.Count == 0) return NotFound();
            return Ok(lst);
        }
        
    }
}
