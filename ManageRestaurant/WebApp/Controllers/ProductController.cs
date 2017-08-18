using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        ProductBLL pdbll = new ProductBLL();
        public ActionResult Index()
        {
            return View("Index", pdbll.getAllProduct());
        }

        public ActionResult Create()
        {
            return View("Create", new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            
            pdbll.AddProduct(product);
            return View("Index");
        }
    }
}