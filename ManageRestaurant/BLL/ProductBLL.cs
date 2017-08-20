
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;


namespace BLL
{
    public class ProductBLL
    {
        ProductDAL eDAL;
        public ProductBLL()
        {
            eDAL = new ProductDAL();
        }
        public List<Product> getAllProduct()
        {
            return eDAL.GetAllProduct();
        }
        public bool AddProduct(Product e)
        {
            if (e != null)
                return eDAL.AddProduct(e);
            return false;
        }
        public bool UpdateProduct(Product e)
        {
            if (e != null) return eDAL.UpdateProduct(e);
            return false;
        }
        public Product GetProductByID(int id)
        {
             return eDAL.GetProductByID(id);
        }
    }
}
