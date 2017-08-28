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
    public class OrderController : ApiController
    {
        OrderDAL oDAL;

        public OrderController()
        {
            oDAL = new OrderDAL();
        }

        public IHttpActionResult GetAllOrder()
        {
            var list = oDAL.GetALlOrder();
            List<OrderViewModel> lst = new List<OrderViewModel>();
            foreach (Order o in list)
            {
                OrderViewModel ovm = new OrderViewModel();
                ovm.OrderID = o.OrderID;
                ovm.ExportDate = o.ExportDate;
                ovm.TableID = o.TableID;
                ovm.Type = o.Type;
                ovm.TotalPrice = o.TotalPrice;
                lst.Add(ovm);
            }
            if (lst.Count == 0) return NotFound();
            return Ok(lst);
        }

        public IHttpActionResult GetOrderById(int id)
        {
            var e = oDAL.GetOrderByID(id);
            if (e == null) return NotFound();
            return Ok(e);
        }


        [HttpPost]
        public IHttpActionResult AddOrder(OrderViewModel o)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data!");

            if (oDAL.AddOrder(new Order()
            {
                //OrderID = o.OrderID,
                TableID=o.TableID,
                ExportDate = o.ExportDate,
                Type = o.Type,
                TotalPrice = o.TotalPrice
                
               
            }))
                return Ok();
            return BadRequest("This employee existed!");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (oDAL.DeleteOrder(id)) return Ok();
            return BadRequest("Can't find out this Employee");
        }
    }
}
