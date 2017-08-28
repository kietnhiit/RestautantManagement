using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
 public   class OrderDAL
    {
        RestaurantDB db;

        public OrderDAL()
        {
            db = new RestaurantDB();
        }

        public List<Order> GetALlOrder()
        {
            try
            {
                List<Order> List = db.Orders.ToList();
                return List;
            }
            catch
            {
                throw;
            }
        }

        public Order GetOrderByID(int id)
        {
            try
            {
                Order o = db.Orders.Find(id);
                return o;
            }
            catch
            {
                throw;
            }
        }

        public bool AddOrder(Order o)
        {
            try
            {
                Order ee = db.Orders.Where(x => x.OrderID == o.OrderID).SingleOrDefault();
                if (ee != null) return false;
                db.Orders.Add(o);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOrder(Order o)
        {
            try
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrder(int id)
        {
            try
            {
                Order o = db.Orders.Find(id);
                if (o != null)
                {
                    db.Orders.Remove(o);
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
