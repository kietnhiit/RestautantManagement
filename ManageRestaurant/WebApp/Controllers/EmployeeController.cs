using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        
        EmployeeDAL eDAL;
        public EmployeeController()
        {
            eDAL = new EmployeeDAL();
        }
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> list = eDAL.GetAllEmployee();
            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee e)
        {
           if(eDAL.AddEmployee(e))   return RedirectToAction("Index");
            ModelState.AddModelError("UserName", "This Username existed");
            return View(e);
        }
        public ActionResult Update(string id)
        {
            Employee e = eDAL.GetEmployeeByID(id);
            return View(e);
        }
        [HttpPost]
        public ActionResult Update(Employee e)
        {
            eDAL.UpdateEmployee(e);
            return RedirectToAction("Index");
        }
    }
}