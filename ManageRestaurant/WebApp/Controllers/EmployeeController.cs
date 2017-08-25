using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using System.Net.Http;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        HttpClient client;
        public EmployeeController()
        {
            client = new HttpClient();
            
        }
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeViewModel> lst = null;
            client.BaseAddress = new Uri("http://localhost:1523/api/");
            var responseTask = client.GetAsync("Employee");
            responseTask.Wait();
            var result = responseTask.Result;
            if(result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<EmployeeViewModel>>();
                readTask.Wait();
                lst = readTask.Result;
            }
            else
            {
                lst = Enumerable.Empty<EmployeeViewModel>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return View(lst);
            
        }
        
        public ActionResult Add()
        {
        /*    List<TypeOfEmployeeBLL> list = tDAL.GetAllType();
            ViewBag.SelectList = list.Select(r => new SelectListItem()
            {
                Value = r.TypeID.ToString(),
                Text = r.NameOfType
            }).ToList();*/
            return View();
        }
        [HttpPost]
        public ActionResult Add(EmployeeViewModel e)
        {
            client.BaseAddress = new Uri("http://localhost:1523/api/Employee");
            var postTask = client.PostAsJsonAsync<EmployeeViewModel>("Employee", e);
            postTask.Wait();
            var result = postTask.Result;
                
            if (result.IsSuccessStatusCode)   return RedirectToAction("Index");
            ModelState.AddModelError(string.Empty, "This Username existed");
            return View(e);
        }
        
        public ActionResult Update(string id)
        {
            EmployeeViewModel e = null;
            client.BaseAddress = new Uri("http://localhost:1523/api/");
            var responseTask = client.GetAsync("Employee?id=" + id);
            responseTask.Wait();
            var result=responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<EmployeeViewModel>();
                readTask.Wait();
                e = readTask.Result;
            }
          /*  List<TypeOfEmployeeBLL> list = tDAL.GetAllType();
            ViewBag.SelectList = list.Select(r => new SelectListItem()
            {
                Value = r.TypeID.ToString(),
                Text = r.NameOfType
            }).ToList();*/
            return View(e);
        }
        [HttpPost]
        public ActionResult Update(EmployeeViewModel e)
        {
            client.BaseAddress = new Uri("http://localhost:1523/api/");
            var putTask = client.PutAsJsonAsync<EmployeeViewModel>("Employee", e);
            putTask.Wait();
            var result = putTask.Result;
            if(result.IsSuccessStatusCode)  return RedirectToAction("Index");
            return View(e);
        }
        public ActionResult Delete(int id)
        {
            EmployeeViewModel e = null;
            client.BaseAddress = new Uri("http://localhost:1523/api/");
            var responseTask = client.GetAsync("Employee?id=" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<EmployeeViewModel>();
                readTask.Wait();
                e = readTask.Result;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete1(string id)
        {
            client.BaseAddress = new Uri("http://localhost:1523/api/");
            var deleteTask = client.DeleteAsync("Employee/" + id);
            deleteTask.Wait();
            var result = deleteTask.Result;
            return RedirectToAction("Index");
        }
    }
}