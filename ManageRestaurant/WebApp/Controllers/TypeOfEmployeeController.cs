using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class TypeOfEmployeeController : Controller
    {
        // GET: TypeOfEmployee
        TypeOfEmployeeDAL rsdal;

        public TypeOfEmployeeController()
        {
            rsdal = new TypeOfEmployeeDAL();
        }
        // GET: TypeOfEmployee
        public ActionResult Index()
        {
            List<TypeOfEmployeeBLL> list = rsdal.GetAllType();
            return View(list);
        }
    }
}