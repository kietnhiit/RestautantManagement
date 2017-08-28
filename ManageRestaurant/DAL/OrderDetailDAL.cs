using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDetailDAL
    {
        RestaurantDB db;

        public OrderDetailDAL()
        {
            db = new RestaurantDB();
        }

        public List<OrderDetail> GetALlOrderDetail()
        {
            try
            {
                List<OrderDetail> List = db.OrderDetails.ToList();
                return List;
            }
            catch
            {
                throw;
            }
        }

        public OrderDetail GetOrderDetailByID(int id)
        {
            try
            {
                OrderDetail od = db.OrderDetails.Find(id);
                return od;
            }
            catch
            {
                throw;
            }
        }

        public bool AddOrderDetail(OrderDetail od)
        {
            try
            {
                OrderDetail ee = db.OrderDetails.Where(x => x.OrderDetailID == od.OrderDetailID).SingleOrDefault();
                if (ee != null) return false;
                db.OrderDetails.Add(od);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOrderDetail(OrderDetail od)
        {
            try
            {
                db.Entry(od).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrderDetail(int id)
        {
            try
            {
                OrderDetail od = db.OrderDetails.Find(id);
                if (od != null)
                {
                    db.OrderDetails.Remove(od);
                    db.SaveChanges();
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
        }
    }
}
