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
    public class FormulaController : ApiController
    {
        FormulaDAL fDAL;
        public FormulaController()
        {
            fDAL = new FormulaDAL();
        }
        //Get
        public IHttpActionResult GetAllType()
        {
            var list = fDAL.GetAllFormula();
            List<FormulaViewModel> lst = new List<FormulaViewModel>();
            foreach (Formula e in list)
            {
                FormulaViewModel tvm = new FormulaViewModel();
                tvm.ProductParentID = e.ProductParentID;
                tvm.ProductID = e.ProductID;
                tvm.Number = e.Number;
                lst.Add(tvm);
            }
            if (lst.Count == 0) return NotFound();
            return Ok(lst);
        }

        //get id
        public IHttpActionResult GetFormulaById(int id)
        {
            var t = fDAL.GetFormulaById(id);
            if (t == null) return NotFound();
            return Ok(t);
        }

        //post
        [HttpPost]
        public IHttpActionResult AddFormula(FormulaViewModel t)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data!");

            if (fDAL.AddFormula(new Formula()
            {
                ProductParentID = t.ProductParentID,
                ProductID=t.ProductID,
                Number=t.Number
            }))
                return Ok();
            return BadRequest("This Formula existed!");
        }

        //put
        [HttpPut]
        public IHttpActionResult Put(FormulaViewModel e)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data!");
            if (fDAL.UpdateFormula(new Formula()
            {
                ProductParentID = e.ProductParentID,
                ProductID = e.ProductID,
                Number = e.Number
            }))
                return Ok();
            return NotFound();
        }


        //delete
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (fDAL.DeleteFormula(id)) return Ok();
            return BadRequest("Can't find out this Formula");
        }
    }
}
