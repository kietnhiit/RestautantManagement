using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL pdbll = new ProductDAL();
        RestaurantDB db = new RestaurantDB();
        public ActionResult Index()
        {
            return View(pdbll.GetAllProduct());
        }

        public ActionResult Create()
        {
            List<Area> listArea = db.Areas.ToList();
            ViewBag.area = listArea;
            ViewBag.SelectList = listArea.Select(r => new SelectListItem()
            {
                Value = r.AreaID.ToString(),
                Text = r.Area1
            }).ToList();
            return View("Create", new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            
            pdbll.AddProduct(product);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            //ViewBag.id = id;
            Product p = pdbll.GetProductByID(id);
            List<Area> listArea = db.Areas.ToList();
            ViewBag.area = listArea;
            ViewBag.SelectList = listArea.Select(r => new SelectListItem() {
                Value = r.AreaID.ToString(),
                Text =  r.Area1
            }).ToList();
            return View(p);
        }
        [HttpPost]
        public ActionResult Update(Product p)
        {
            pdbll.UpdateProduct(p);
            return RedirectToAction("Index");
        }
    }
}