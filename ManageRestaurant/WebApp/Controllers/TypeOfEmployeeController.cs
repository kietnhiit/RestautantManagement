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

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Add(TypeOfEmployeeBLL model)
        {
            if (ModelState.IsValid)
            {
                var ct = new TypeOfEmployeeBLL
                {
                    TypeID = model.TypeID,
                    NameOfType = model.NameOfType
                };

                //cbo.AddCategory(ct);
                rsdal.AddTypeOfEmployee(ct);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Update(int id)
        {
            TypeOfEmployeeBLL type = rsdal.GetTypeById(id);
            return View(type);
        }
        [HttpPost]
        public ActionResult Update(TypeOfEmployeeBLL e)
        {
            rsdal.UpdateTypeOfEmployee(e);
            return RedirectToAction("Index");
        }

    }
}