using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDAL
    {
        RestaurantDB db;
       public EmployeeDAL()
        {
            db = new RestaurantDB();
        }
        public bool AddEmployee(Employee e)
        {
            try
            {
                Employee ee = db.Employees.Where(x => x.Username == e.Username).SingleOrDefault();
                if (ee != null) return false;
                db.Employees.Add(e);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateEmployee(Employee e)
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
        public Employee GetEmployeeByID(int id)
        {
            try
            {
                Employee e = db.Employees.Find(id);
                return e;
            }
            catch
            {
                return null;
            }
        }

        public List<Employee> GetAllEmployee()
        {
            try
            {
                List<Employee> List = db.Employees.ToList();
                return List;
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteEmployee(int id)
        {
            try
            {
                Employee ep = db.Employees.Find(id);
                if(ep!=null)
                {
                    db.Employees.Remove(ep);
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
