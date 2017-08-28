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
        TypeOfEmployeeDAL tDAL;
        public EmployeeController()
        {
            eDAL = new EmployeeDAL();
            tDAL = new TypeOfEmployeeDAL();
        }
        public IHttpActionResult GetAllEmployee()
        {
            var list = eDAL.GetAllEmployee();
            List<EmployeeViewModel> lst = new List<EmployeeViewModel>();
            foreach (Employee e in list)
            {
                EmployeeViewModel evm = new EmployeeViewModel();
                evm.EmployeeID = e.EmployeeID;
                evm.Address = e.Address;
                evm.FirstName = e.FirstName;
                evm.Gender = e.Gender;
                evm.LastName = e.LastName;
                evm.Password = e.Password;
                evm.Phone = e.Phone;
                evm.TypeID = e.TypeID;
                evm.TypeName = tDAL.GetTypeById(e.TypeID).NameOfType;
                evm.Username = e.Username;
                lst.Add(evm);
            }
            if (lst.Count == 0) return NotFound();
            return Ok(lst);
        }
        public IHttpActionResult GetEmployeeById(int id)
        {
            var e = eDAL.GetEmployeeByID(id);
            if (e == null) return NotFound();
            return Ok(e);
        }
        [HttpPost]
        public IHttpActionResult AddEmployee(EmployeeViewModel e)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data!");
            
            if (eDAL.AddEmployee(new Employee()
            {
                Address = e.Address,
                FirstName = e.FirstName,
                Gender = e.Gender,
                LastName = e.LastName,
                Password = e.Password.Trim(),
                Phone = e.Phone,
                TypeID = e.TypeID,
                Username = e.Username
            }))
                return Ok();
            return BadRequest("This employee existed!");
        }
        [HttpPut]
        public IHttpActionResult Put(EmployeeViewModel e)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data!");
            if (eDAL.UpdateEmployee(new Employee()
            {
                EmployeeID = e.EmployeeID,
                Address = e.Address,
                FirstName = e.FirstName,
                Gender = e.Gender,
                LastName = e.LastName,
                Password = e.Password.Trim(),
                Phone = e.Phone,
                TypeID = e.TypeID,

                Username = e.Username
            }))
                return Ok();
            return NotFound();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (eDAL.DeleteEmployee(id)) return Ok();
            return BadRequest("Can't find out this Employee");
        }
    }
}
