using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class TableController : Controller
    {
        TableDAL tDAL;
        // GET: Table
        public TableController()
        {
            tDAL = new TableDAL();
        }
        // GET: Employee
        public ActionResult Index()
        {
            List<Table> list = tDAL.GetAllTable();
            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Table t)
        {
            if (tDAL.AddTable(t)) return RedirectToAction("Index");
            ModelState.AddModelError("Area", "This Area existed");
            return View(t);
        }
        public ActionResult Update(int id)
        {
            Table t = tDAL.GetTableById(id);
            return View(t);
        }
        [HttpPost]
        public ActionResult Update(Table t)
        {
            tDAL.UpdateTable(t);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Table t = tDAL.GetTableById(id);
            return View(t);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Table t = tDAL.GetTableById(id);
                tDAL.DeleteTable(id);
                return RedirectToAction("Index");
            }
            else
            {
                return View(id);
            }
        }
    }
}