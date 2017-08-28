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
    public class OrderDetailController : ApiController
    {
        OrderDetailDAL odDAL;

        public OrderDetailController()
        {
            odDAL = new OrderDetailDAL();
        }

        public IHttpActionResult GetAllOrderDetail()
        {
            var list = odDAL.GetALlOrderDetail();
            List<OrderDetailViewModel> lst = new List<OrderDetailViewModel>();
            foreach (OrderDetail o in list)
            {
                OrderDetailViewModel ovm = new OrderDetailViewModel();
                ovm.OrderDetailID = o.OrderDetailID;
                ovm.OrderID = o.OrderID;
                ovm.Number = o.Number;
                ovm.ProductID = o.ProductID;
                ovm.Prices = o.Prices;
                lst.Add(ovm);
            }
            if (lst.Count == 0) return NotFound();
            return Ok(lst);
        }

        public IHttpActionResult GetOrderDetailById(int id)
        {
            var e = odDAL.GetOrderDetailByID(id);
            if (e == null) return NotFound();
            return Ok(e);
        }


        [HttpPost]
        public IHttpActionResult AddOrder(OrderDetailViewModel od)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data!");

            if (odDAL.AddOrderDetail(new OrderDetail()
            {
                //OrderID = o.OrderID,

                OrderID = od.OrderID,
                Number = od.Number,
                ProductID = od.ProductID,
                Prices = od.Prices


            }))
                return Ok();
            return BadRequest("This employee existed!");

        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (odDAL.DeleteOrderDetail(id)) return Ok();
            return BadRequest("Can't find out this Employee");
        }
    }
}
