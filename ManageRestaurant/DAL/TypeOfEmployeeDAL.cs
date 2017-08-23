using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class TypeOfEmployeeDAL
    {
        RestaurantDB db;
        public TypeOfEmployeeDAL()
        {
            db = new RestaurantDB();
        }

        public TypeOfEmployeeBLL GetTypeById(int id)
        {
            try
            {
                TypeOfEmployeeBLL type = db.TypeOfEmployees.Find(id);
                return type;
            }
            catch
            {
                return null;
            }
        }

        public List<TypeOfEmployeeBLL> GetAllType()
        {
            try
            {
                List<TypeOfEmployeeBLL> list = db.TypeOfEmployees.ToList();
                return list;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool UpdateTypeOfEmployee(TypeOfEmployeeBLL type)
        {
            try
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddTypeOfEmployee(TypeOfEmployeeBLL type)
        {
            try
            {
                db = new DAL.RestaurantDB();
                db.TypeOfEmployees.Add(type);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
