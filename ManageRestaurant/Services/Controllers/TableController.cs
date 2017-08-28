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
    public class TableController : ApiController
    {
        TableDAL tDAL;
        public TableController()
        {
            tDAL = new TableDAL();
        }
        //Get
        public IHttpActionResult GetAllType()
        {
            var list = tDAL.GetAllTable();
            List<TableViewModel> lst = new List<TableViewModel>();
            foreach (Table e in list)
            {
                TableViewModel tvm = new TableViewModel();
                tvm.TableID = e.TableID;
                tvm.Area = e.Area;
                lst.Add(tvm);
            }
            if (lst.Count == 0) return NotFound();
            return Ok(lst);
        }

        //get id
        public IHttpActionResult GetTableById(int id)
        {
            var t = tDAL.GetTableById(id);
            if (t == null) return NotFound();
            return Ok(t);
        }

        //post
        [HttpPost]
        public IHttpActionResult AddTable(TableViewModel t)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data!");

            if (tDAL.AddTable(new Table()
            {
                Area = t.Area
            }))
                return Ok();
            return BadRequest("This Table existed!");
        }

        //put
        [HttpPut]
        public IHttpActionResult UpdateTable(TableViewModel e)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data!");
            if (tDAL.UpdateTable(new Table()
            {
                TableID = e.TableID,
                Area = e.Area             
            }))
                return Ok();
            return NotFound();
        }


        //delete
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (tDAL.DeleteTable(id)) return Ok();
            return BadRequest("Can't find out this Table");
        }
    }
}
