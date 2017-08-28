using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class TypeOfEmployeeBLL
    {
        TypeOfEmployeeBLL rsdal;

        public TypeOfEmployeeBLL GetTypeById(int id)
        {
            if (id.ToString() != " ")
            {
                return rsdal.GetTypeById(id);
            }
            return null;
        }

        public List<DAL.TypeOfEmployeeBLL> GetAllType()
        {
            try
            {
                return rsdal.GetAllType();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddTypeOfEmployee(DAL.TypeOfEmployeeBLL type)
        {
            try
            {
                if (type != null)
                {
                    return rsdal.AddTypeOfEmployee(type);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateTypeOfEmployee(DAL.TypeOfEmployeeBLL type)
        {
            try
            {
                if (type != null)
                {
                    return rsdal.UpdateTypeOfEmployee(type);
                }
                return false;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public TypeOfEmployeeBLL()
        {
            rsdal = new TypeOfEmployeeBLL();
        }
    }
}
