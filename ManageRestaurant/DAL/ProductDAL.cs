using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDAL
    {
        RestaurantDB db;
        public ProductDAL()
        {
            db = new RestaurantDB();
        }
        public bool AddProduct(Product e)
        {
            try
            {
                Product ee = db.Products.Where(x => x.ProductID == e.ProductID).SingleOrDefault();
                if (ee != null) return false;
                db.Products.Add(e);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateProduct(Product e)
        {
            try
            {
                db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public Product GetProductByID(int id)
        {
            try
            {
                Product e = db.Products.Find(id);
                return e;
            }
            catch
            {
                throw;
            }
        }

        public List<Product> GetAllProduct()
        {
            try
            {
                List<Product> List = db.Products.ToList();
                return List;
            }
            catch
            {
                throw;
            }
        }
    }
}
