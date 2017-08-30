using DAL;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.Controllers
{
    public class TypeOfEmployeeController : ApiController
    {
        TypeOfEmployeeDAL tDAL;
        public TypeOfEmployeeController()
        {
            
            tDAL = new TypeOfEmployeeDAL();
        }
        //Get
        public IHttpActionResult GetAllType()
        {
            var list = tDAL.GetAllType();
            List<TypeOfEmployeeViewModel> lst = new List<TypeOfEmployeeViewModel>();
            foreach (TypeOfEmployeeBLL e in list)
            {
                TypeOfEmployeeViewModel tvm = new TypeOfEmployeeViewModel();
                tvm.TypeID = e.TypeID;
                tvm.NameOfType = e.NameOfType;
                lst.Add(tvm);
            }
            if (lst.Count == 0) return NotFound();
            return Ok(lst);
        }

        //get id
        public IHttpActionResult GetTypeById(int id)
        {
            var t = tDAL.GetTypeById(id);
            if (t == null) return NotFound();
            return Ok(t);
        }

        //post
        [HttpPost]
        public IHttpActionResult AddType(TypeOfEmployeeViewModel t)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data!");

            if (tDAL.AddTypeOfEmployee(new TypeOfEmployeeBLL()
            {
                NameOfType = t.NameOfType
            }))
                return Ok();
            return BadRequest("This Type existed!");
        }

        //put
        [HttpPut]
        public IHttpActionResult Put(TypeOfEmployeeViewModel e)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data!");
            if (tDAL.UpdateTypeOfEmployee(new TypeOfEmployeeBLL()
            {
                TypeID = e.TypeID,
                NameOfType = e.NameOfType
            }))
                return Ok();
            return NotFound();
        }


        //delete
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (tDAL.DeleteTypeEmployee(id)) return Ok();
            return BadRequest("Can't find out this Employee");
        }
    }
}
