using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class EmployeeBLL
    {
        EmployeeDAL eDAL;
        public EmployeeBLL()
        {
            eDAL = new EmployeeDAL();
        }
        public eEmployee getEmployeeByID(int id)
        {
            if (id != null)
            {
                Employee e= eDAL.GetEmployeeByID(id);
                eEmployee ee = new eEmployee();
                ee.Address = e.Address;
                ee.EmployeeID = e.EmployeeID;
                ee.FirstName = e.FirstName;
                ee.Gender = e.Gender;
                ee.LastName = e.LastName;
                ee.Password = e.Password;
               // ee.Phone = e.Phone;
                ee.TypeID = e.TypeID;
                ee.Username = e.Username;
            }
            return null;
        }
        public List<Employee> getAllEmployee()
        {
            return eDAL.GetAllEmployee();
        }
        public bool AddEmployee(Employee e)
        {
            if (e != null) return eDAL.AddEmployee(e);
            return false;
        }
        public bool UpdateEmployee(Employee e)
        {
            if (e != null) return eDAL.UpdateEmployee(e);
            return false;
        }
    }
}
