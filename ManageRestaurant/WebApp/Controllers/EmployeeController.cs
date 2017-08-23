using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        
        EmployeeDAL eDAL;
        TypeOfEmployeeDAL tDAL;
        
        public EmployeeController()
        {
            eDAL = new EmployeeDAL();
            tDAL = new TypeOfEmployeeDAL();
        }
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> list = eDAL.GetAllEmployee();
            List<EmployeeViewModel> liste = new List<EmployeeViewModel>();
            foreach(Employee e in list)
            {
                EmployeeViewModel evm = new EmployeeViewModel();
                evm.EmployeeID = e.EmployeeID;
                evm.Address = e.Address;
                evm.FirstName = e.FirstName;
                evm.Gender = e.Gender;
                evm.LastName = e.LastName;
                evm.Password = e.Password;
                evm.Phone = e.Phone;
                evm.TypeName = tDAL.GetTypeById(e.TypeID).NameOfType;
                evm.Username = e.Username;
                liste.Add(evm);
            }
            return View(liste);
        }
        public ActionResult Add()
        {
            List<TypeOfEmployeeBLL> list = tDAL.GetAllType();
            ViewBag.SelectList = list.Select(r => new SelectListItem()
            {
                Value = r.TypeID.ToString(),
                Text = r.NameOfType
            }).ToList();
            return View("Add", new Employee());
        }
        [HttpPost]
        public ActionResult Add(Employee e)
        {
           if(eDAL.AddEmployee(e))   return RedirectToAction("Index");
            ModelState.AddModelError("UserName", "This Username existed");
            return View(e);
        }
        public ActionResult Update(int id)
        {
            Employee e = eDAL.GetEmployeeByID(id);
            List<TypeOfEmployeeBLL> list = tDAL.GetAllType();
            ViewBag.SelectList = list.Select(r => new SelectListItem()
            {
                Value = r.TypeID.ToString(),
                Text = r.NameOfType
            }).ToList();
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